using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    //prefabs
    [SerializeField]
    GameObject rightPath;
    [SerializeField]
    GameObject leftPath; 
    [SerializeField]
    GameObject CenterPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gamePrefab;
        int prefabNumber = Random.Range(0, 3);
    }
}
