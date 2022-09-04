using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] childList;

    private Vector3 current, previous;
    private void Awake()
    {
        childList = GetComponentsInChildren<Transform>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        childList = GetComponentsInChildren<Transform>();
        if (childList.Length>=1)
        {
            previous = childList[1].position;
            Gizmos.DrawWireSphere(previous, .2f);

            for (int i = 2; i < childList.Length; ++i)
            {
                current = childList[i].position;
                Gizmos.DrawLine(previous, current);
                Gizmos.DrawWireSphere(current, .2f);
                previous = current;
            }
        }
    }

    public Transform getAt(int i)
    {
        if (i >childList.Length-1)
            return null;
        return childList[i];
    }

    public int getSize()
    {
        return childList.Length-1;
    }
}
