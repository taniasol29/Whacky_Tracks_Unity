using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadGamePageController : MonoBehaviour
{
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button newPlayerButton;
    [SerializeField] private Button goBackButton;

    public UnityEvent GoBackButtonClicked;
    public UnityEvent NewPlayerButtonClicked;

    void OnClickGoBackButtton()
    {
        GoBackButtonClicked?.Invoke();
    }

    void OnClickNewPlayerButton()
    {
        NewPlayerButtonClicked?.Invoke();
    }
    private void Awake()
    {
        goBackButton.onClick.AddListener(OnClickGoBackButtton);
        newPlayerButton.onClick.AddListener(OnClickNewPlayerButton);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
