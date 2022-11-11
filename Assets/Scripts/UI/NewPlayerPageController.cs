using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewPlayerPageController : MonoBehaviour
{
    [SerializeField] private Button enterButton;
    [SerializeField] private Button goBackButton;

    public UnityEvent EnterButtonClicked;
    public UnityEvent GoBackButtonClicked;

    void OnClickGoBackButtton()
    {
        GoBackButtonClicked?.Invoke();
    }
    
    void OnClickEnterButtton()
    {
        GoBackButtonClicked?.Invoke();
    }

    void Awake()
    {
        goBackButton.onClick.AddListener(OnClickGoBackButtton);
        enterButton.onClick.AddListener(OnClickEnterButtton);
    }

    void Update()
    {
        
    }
}
