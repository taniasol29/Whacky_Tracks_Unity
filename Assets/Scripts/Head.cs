using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;

    public Path path;
    public int pointIndex;
    private float threshhold = 1e-6f;


    private void Update()
    {


        Transform target = path.getAt(pointIndex);
        
        float distance = Vector3.Distance(target.position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 look = target.position - transform.position;
            if (look != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(look);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }


            if (distance <= threshhold) 
            {
                ++pointIndex;
            }


            if (pointIndex > path.getSize())
            {
                pointIndex = 1;
            }


        }

}
