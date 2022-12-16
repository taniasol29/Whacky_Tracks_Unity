using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public RawImage rImage;
    private float startTime;
    private float fading;
    private bool startFade = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= 1.0f) { startFade = true; }

        if (startFade)
        {
            fading += Time.deltaTime / 3.0f;
            fading = Mathf.Clamp01(fading);
            Color color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            rImage.color = Color.Lerp(Color.black, color, fading);
        }
    }
}
