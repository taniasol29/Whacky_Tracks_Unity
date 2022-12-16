using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeOut : MonoBehaviour
{
    CanvasGroup canGroup;
    public float speed = 10f;
    public  float a;

  
    private void Awake()
    {
        canGroup=GameObject.Find("Canvas").GetComponent<CanvasGroup>();
    }
    private void Update() 
    {
        if(LoadNextScene.fade== true)
        {
            StartCoroutine(FadeOutt());
            LoadNextScene.fade=false;
     }
    }
    IEnumerator FadeOutt()
    {
        canGroup.alpha = 1;
       
        while(canGroup.alpha >0)
        {
            canGroup.alpha -= Time.deltaTime *speed;
            yield return null;
        }
        LoadNextScene.go=true;
    }
}
