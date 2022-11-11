using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HomePageController : MonoBehaviour
{
    [SerializeField] private Button startButton;

    public UnityEvent StartButtonClicked;
    
    void OnClickStartButton()
    {
        StartButtonClicked?.Invoke();
    }

    private void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton); // relier la fonction à l'évènement onClick du bouton
    }

    
    void Update()
    {
        
    }
}