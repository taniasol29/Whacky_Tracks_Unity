using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;

    //path
    private GameObject startGameObject;
    private Path path;
    private int pathIndex = 0;
    private int pointIndex = 1;
    private float threshhold = 1e-6f;

    //game/input
    private bool gameOver = false;
    private bool ispressed = false;
    private bool startGame = false;

    //prefabs
    [SerializeField]
    GameObject centerPrefab;
    [SerializeField]
    GameObject leftPrefab;
    [SerializeField]
    GameObject rightPrefab;

    //dynamic prefabs generation
    private const int tabsize = 6;
    private GameObject[] prefabs = new GameObject[tabsize];
    private bool[] status = new bool[tabsize];
    private int startPos = -38;
    private int offset = 42;
    //pre order
    private int previous = 1;
    private int current = 0;
    private int next = 2;

    //collision
    string colliderName;

    //UI
    public GameObject sign;
    public GameObject timer;
    public GameObject go;
    public Sprite clock1;
    public Sprite clock2;
    float time = 0;
    bool start = false;

    //Enemy
    public GameObject GreenEnemy;
    public GameObject BlueEnemy;
    public GameObject YellowEnemy;

    //Life indicator
    public GameObject GreenLife;
    public GameObject BlueLife;
    public GameObject YellowLife;

    int enemyCount = 3;

    private void Start()
    {
        prefabs[0]= Instantiate<GameObject>(rightPrefab);
       
        prefabs[1]= Instantiate<GameObject>(leftPrefab);
        // Don't count score on first tile
        var tileSuccessTrigger = prefabs[1].GetComponentInChildren<TileSuccessTrigger>();
        tileSuccessTrigger.isFirstTile = true;

        prefabs[2]= Instantiate<GameObject>(centerPrefab);
        prefabs[3]= Instantiate<GameObject>(rightPrefab);
        prefabs[4]= Instantiate<GameObject>(leftPrefab);
        prefabs[5]= Instantiate<GameObject>(centerPrefab);
        for(int i=0;i< tabsize; ++i)
        {
            prefabs[i].SetActive(false);
            status[i] = false;
        }

        Show(previous);
        Show(current);
        Show(next);
    }


    void Update()
    {
        if(startGame)
        {
            if (!gameOver)
            {
                if(GreenEnemy)
                {
                    if (GreenEnemy.GetComponent<Enemy>().isOver())
                    {
                        Destroy(GreenLife);
                    }   
                }
                
                if(BlueEnemy)
                {
                    if (BlueEnemy.GetComponent<Enemy>().isOver())
                    {
                        Destroy(BlueLife);
                    }   
                }

                if (YellowEnemy)
                {
                    if (YellowEnemy.GetComponent<Enemy>().isOver())
                    {
                        Destroy(YellowLife);
                    }    
                }

                if (enemyCount==0)
                {
                    ScoresManager.Instance.HandleGameOver();
                    SceneManager.LoadScene("Victory");
                    Debug.Log("victory");
                }

                if (path)// if path is valid object
                {
                    if (!ispressed)
                    {
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            path = startGameObject.transform.GetChild(1).GetComponent<Path>();
                            ispressed = true;
                        }

                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            path = startGameObject.transform.GetChild(2).GetComponent<Path>();
                            ispressed = true;
                        }

                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            path = startGameObject.transform.GetChild(0).GetComponent<Path>();
                            ispressed = true;
                        }
                    }

                    Transform target = path.getAt(pointIndex);
                    if (target)//following path motion
                    {
                        float distance = Vector3.Distance(target.position, transform.position);
                        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                        Vector3 look = target.position - transform.position;
                        if (look != Vector3.zero)
                        {
                            var rotation = Quaternion.LookRotation(look);
                            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                        }

                        if (distance <= threshhold) // if target is reached
                        {
                            ++pointIndex; //set target to next target
                        }

                        if (pointIndex > path.getSize())//last point
                        {
                            //reset to next prefab
                            pointIndex = 1;
                            path = null; //invalidate path

                        }
                    }
                }
                else //forward motion
                {
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }

                if (start)
                    CountDown();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliderName = other.gameObject.name;
        if (colliderName == "Start")
        {
            startGameObject = other.gameObject; //get the object that holde  paths
            path = startGameObject.transform.GetChild(0).GetComponent<Path>(); //set default path to center
            ispressed = false;
            Hide(previous);
            previous = current;
            current = next;
            start = true;
            do
            {
                next = Random.Range(0, tabsize);
            } while (status[next]==true);
            Show(next);

            if (GreenEnemy)
            {
                if (GreenEnemy.GetComponent<Enemy>().isOver())
                {
                    --enemyCount;
                    Destroy(GreenEnemy);
                }
                    
            }
            if (BlueEnemy)
            {
                if (BlueEnemy.GetComponent<Enemy>().isOver())
                {
                    --enemyCount;
                    Destroy(BlueEnemy);
                }
                    
            }
            if (YellowEnemy)
            {
                if (YellowEnemy.GetComponent<Enemy>().isOver())
                {
                    --enemyCount;
                    Destroy(YellowEnemy);
                }       
            }  
        }

        if (colliderName == "End")
        {
            ispressed = true; //end of choice
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true); //show wrong way panel
            
            Reset();
        }

        if (colliderName == "GameOver")
        {
            ScoresManager.Instance.HandleGameOver();
            gameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    void Show(int i)
    {
        prefabs[i].transform.position = Vector3.forward * startPos;
        status[i] = true;
        prefabs[i].SetActive(true);
        startPos += offset;
    }

    void Hide(int i)
    {
        status[i] = false;
        prefabs[i].SetActive(false);
    }

    void CountDown()
    {
        time += Time.deltaTime;
        int count= 3 - Mathf.FloorToInt(time);
        sign.SetActive(true);
        timer.SetActive(true);
        StartCoroutine(ClockCouroutine());
        timer.transform.GetChild(1).GetComponent<Text>().text =  count.ToString();
    }

    void Reset()
    {
        start = false;
        time = 0;
        sign.SetActive(false);
        timer.SetActive(false);
    }

    IEnumerator ClockCouroutine()
    {
        Sprite sprite = timer.transform.GetChild(0).GetComponent<Image>().sprite;
        if (sprite.name == "clock1")
            timer.transform.GetChild(0).GetComponent<Image>().sprite = clock2;
        else
            timer.transform.GetChild(0).GetComponent<Image>().sprite = clock1;
        yield return new WaitForSeconds(5);
    }

    public void OnGo()
    {
        startGame = true;
        GreenEnemy.GetComponent<Enemy>().Go();
        BlueEnemy.GetComponent<Enemy>().Go();
        YellowEnemy.GetComponent<Enemy>().Go();
        go.SetActive(false);
    }
}
