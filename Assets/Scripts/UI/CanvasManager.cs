using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private HomePageController homePage;
    [SerializeField] private LoadGamePageController loadGamePage;
    [SerializeField] private NewPlayerPageController newPlayerPage;
    [SerializeField] private ChoosePlayerPageController choosePlayerPage;
    [SerializeField] private MainMenuPageController mainMenuPage;

    private void Awake()
    {
        homePage.StartButtonClicked.AddListener(ShowLoadGamePage);

        loadGamePage.GoBackButtonClicked.AddListener(ShowHomePage);
        loadGamePage.NewPlayerButtonClicked.AddListener(ShowNewPlayerPage);
        loadGamePage.LoadGameButtonClicked.AddListener(ShowChoosePlayerPage);

        newPlayerPage.GoBackButtonClicked.AddListener(ShowHomePage);
        newPlayerPage.EnterButtonClicked.AddListener(ShowMainMenuPage);

        mainMenuPage.QuitButtonClicked.AddListener(Quit);
        mainMenuPage.PlayButtonClicked.AddListener(LoadGameScene);

        choosePlayerPage.GoBackButtonClicked.AddListener(ShowHomePage);
    }

    void Start()
    {
        ShowHomePage();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowChoosePlayerPage()
    {
        loadGamePage.gameObject.SetActive(false);
        newPlayerPage.gameObject.SetActive(false);
        choosePlayerPage.gameObject.SetActive(true);
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
        choosePlayerPage.gameObject.SetActive(false);
        homePage.gameObject.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
