using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

    public RawImage rImage;
    private float startTime;
    private bool isTime = false;
    void awake()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
            if(!isTime)
            {
                startTime = Time.time;
                isTime = true;
            }
            float t = Mathf.Clamp01((Time.time - startTime) / 5);
            rImage.color = Color.Lerp(Color.black, Color.white, t );
            if(t>=1)
                rImage.enabled = false;
            
    }
}
