using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 newScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float scaleTime = 0.5f;
    private IEnumerator scaleCoroutine;

    IEnumerator DoScale(float t, Vector3 dest)
    {
        var depart = transform.localScale;
        float elapsedTime = 0;

        while(elapsedTime < t)
        {
            transform.localScale = Vector3.Lerp(depart, dest, elapsedTime/t);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = dest;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale(newScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Scale(Vector3.one);
    }

    private void Scale(Vector3 dest)
    {
        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = DoScale(scaleTime, dest);
        StartCoroutine(scaleCoroutine);
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.one;
    }
}
