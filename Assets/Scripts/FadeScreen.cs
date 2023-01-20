using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public RawImage rImage;
    private float startTime = 0.0f;
    private float fading = 0.0f;
    private float fadeTime = 2.0f;
    private bool startFade = false;
    private Color fadeOutColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    void Start()
    {
        rImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= 0.2f) { startFade = true; }

        if (startFade && fading <= fadeTime)
        {
            fading += Time.deltaTime;
            rImage.color = Color.Lerp(Color.black, fadeOutColor, fading / fadeTime); 
        }

        //Debug.Log("Fading " + fading);

        if (fading >= fadeTime)
            rImage.gameObject.SetActive(false);
    }
}
