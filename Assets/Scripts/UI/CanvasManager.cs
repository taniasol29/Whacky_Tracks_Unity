using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private HomePageController homePage;
    [SerializeField] private LoadGamePageController loadGamePage;
    [SerializeField] private NewPlayerPageController newPlayerPage;
    [SerializeField] private MainMenuPageController mainMenuPage;

    private void Awake()
    {
        homePage.StartButtonClicked.AddListener(ShowLoadGamePage);
        loadGamePage.GoBackButtonClicked.AddListener(ShowHomePage);
        loadGamePage.NewPlayerButtonClicked.AddListener(ShowNewPlayerPage);
        newPlayerPage.GoBackButtonClicked.AddListener(ShowHomePage);
        newPlayerPage.EnterButtonClicked.AddListener(ShowMainMenuPage);
    }

    void Start()
    {
        ShowHomePage();
    }

    public void ShowMainMenuPage()
    {
        newPlayerPage.gameObject.SetActive(false);
        mainMenuPage.gameObject.SetActive(true);
    }
    public void ShowNewPlayerPage()
    {
        loadGamePage.gameObject.SetActive(false);
        newPlayerPage.gameObject.SetActive(true);
    }
    
    public void ShowLoadGamePage() // désactiver toutes les pages sauf LoadGame
    {
        homePage.gameObject.SetActive(false);
        loadGamePage.gameObject.SetActive(true);
    }

    public void ShowHomePage()
    {
        loadGamePage.gameObject.SetActive(false);
        homePage.gameObject.SetActive(true);
    }
}
