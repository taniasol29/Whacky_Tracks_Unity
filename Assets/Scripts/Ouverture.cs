using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ouverture : MonoBehaviour
{
    AsyncOperation asyncLoadScene;
    CanvasGroup canGroup;
    public float speed=0.2f;
    public  float a;

  
    private void Awake()
    {
        canGroup=GameObject.Find("Canvas").GetComponent<CanvasGroup>();
    }
    void Start()
    {
        StartCoroutine(LoadIntroScene());

    }

    private void Update() 
    {
        if(Input.GetButton("Jump")== true)
        StartCoroutine(FadeOutt());

    }
   
    IEnumerator LoadIntroScene()
    {
        asyncLoadScene= SceneManager.LoadSceneAsync("Intro");
        asyncLoadScene.allowSceneActivation=false;
        yield return null;
    }
    IEnumerator FadeOutt()
    {
        canGroup.alpha = 1;
       
        while(canGroup.alpha >0)
        {
            canGroup.alpha -= Time.deltaTime *speed;
            yield return null;
        }
        asyncLoadScene.allowSceneActivation=true;

    }



}