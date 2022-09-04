using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSensor : MonoBehaviour
{
    public GameObject detectedDestination;
    
    // Start is called before the first frame update
    void Start()
    {
        detectedDestination = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "trainDestination")
        {
            detectedDestination = other.gameObject;
            Debug.Log("Destination point detected!");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "trainDestination")
        {
            Debug.Log("Destination point undetected!");
            //detectedDestination = null;
        }
    }
}
