using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] rightPath;
    public Transform[] centerPath;
    public Transform[] leftPath;

    public float speed = 5.0f;
    public float turningSpeed = 4.0f;
    public float reachDistance = 1.0f;
    public int currentPoint = 0;
    //bool moveTrain = false;
    bool w;
    bool a;
    bool d;
    private void Start()
    {
       
    }

    private void Update()
    {
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        d = Input.GetKey(KeyCode.D);

        if (w)
        {
            //makeTrainMove(centerPath);
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        else if(a)
        {
            makeTrainMove(leftPath);
        }
        else if(d)
        {
            makeTrainMove(rightPath);
        }
    }

   void makeTrainMove(Transform[] p)
    {
        Vector3 direction = p[currentPoint].position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turningSpeed);
        float dist = Vector3.Distance(p[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, p[currentPoint].position, Time.deltaTime * speed);

        if (dist <= reachDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= p.Length)
        {
            currentPoint = 0;
        }
    }
}
