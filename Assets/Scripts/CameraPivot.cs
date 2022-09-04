using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{

    public Transform trainTransform;
    public GameObject lookSpot;
    
    


    // Start is called before the first frame update
    void Start()
    {
        GameObject lookspot = GameObject.Find("Lokomotive A") ;
        
    }

    // Update is called once per frame
    void Update()
    {
        trainTransform = lookSpot.transform;

        transform.LookAt(trainTransform);

        transform.Translate(Vector3.right * 2 * Time.deltaTime);
    }
}
