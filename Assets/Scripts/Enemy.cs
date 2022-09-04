using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    //private bool ispressed = false;
    private bool startGame = false;


    
    

    //collision
    string colliderName;

    


    private void Start()
    {

    }


    void Update()
    {
        if(!gameOver)
        {
            if (startGame)
            {
                if (path)// if path is valid object
                {
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
                            ++pointIndex;//set target to next target
                        }


                        if (pointIndex > path.getSize())//last point
                        {
                            //reset to next prefab
                            pointIndex = 1;
                            path = null;//invalidate path

                        }
                    }
                }
                else//forward motion
                {
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliderName = other.gameObject.name;
        if (colliderName == "Start")
        {
            startGameObject = other.gameObject;//get the object that holde  paths
            int n = Random.Range(0, 2);
            path = startGameObject.transform.GetChild(n).GetComponent<Path>();
        }

        if (colliderName == "GameOver")
        {
            gameOver = true;
        }


    }

    public void Go()
    {
        startGame = true;
    }

    public bool isOver()
    {
        return gameOver;
    }

}
