using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMoving : MonoBehaviour
{
    private float z;
    GameObject newTile;
    public GameObject tile;
     void Start()
    {
        z = gameObject.transform.position.z;
        newTile = Instantiate(tile, new Vector3(0,0,z+198.0f), Quaternion.Euler(-90.0f,0.0f,0.0f));

    }
    
    void Update()
    {
        
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);
                if(transform.position.z >= z + 198.0f)
                {
                   newTile = Instantiate(tile, new Vector3(0,0,z+396.0f), Quaternion.Euler(-90.0f,0.0f,0.0f));
                   z = gameObject.transform.position.z;

                }


    }
}
