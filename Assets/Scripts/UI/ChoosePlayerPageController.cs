using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChoosePlayerPageController : MonoBehaviour
{
    [SerializeField] private Button goBackButton;

    public UnityEvent GoBackButtonClicked;

    void OnClickGoBackButton()
    {
        GoBackButtonClicked?.Invoke();
    }
    
    void Awake()
    {
        goBackButton.onClick.AddListener(OnClickGoBackButton);
    }

    void Update()
    {
        
    }
}
