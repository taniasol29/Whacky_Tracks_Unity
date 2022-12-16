using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private HomePageController _homePage;
    [SerializeField] private LoadGamePageController _loadGamePage;
    [SerializeField] private NewPlayerPageController _newPlayerPage;
    [SerializeField] private ChoosePlayerPageController _choosePlayerPage;
    [SerializeField] private MainMenuPageController _mainMenuPage;

    private void Awake()
    {
        // Home page
        _homePage.StartButtonClicked.AddListener(ShowLoadGamePage);

        // Load Page
        _loadGamePage.GoBackButtonClicked.AddListener(ShowHomePage);
        _loadGamePage.NewPlayerButtonClicked.AddListener(ShowNewPlayerPage);
        _loadGamePage.LoadGameButtonClicked.AddListener(ShowChoosePlayerPage);

        // New Player page
        _newPlayerPage.GoBackButtonClicked.AddListener(ShowHomePage);
        _newPlayerPage.EnterButtonClicked.AddListener(ShowMainMenuPage);

        // Choose Player page
        _choosePlayerPage.GoBackButtonClicked.AddListener(ShowHomePage);
        _choosePlayerPage.PlayerSelected.AddListener(ShowMainMenuPage);

        // Main Menu page
        _mainMenuPage.QuitButtonClicked.AddListener(Quit);
        _mainMenuPage.PlayButtonClicked.AddListener(LoadGameScene);
    }

    void Start()
    {
        ShowHomePage();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowNewPlayerPage()
    {
        _newPlayerPage.gameObject.SetActive(true);
    }

    public void ShowChoosePlayerPage()
    {
        _choosePlayerPage.gameObject.SetActive(true);
    }
    
    public void ShowMainMenuPage()
    {
        _mainMenuPage.gameObject.SetActive(true);
    }
    
    public void ShowLoadGamePage() 
    {
        _loadGamePage.gameObject.SetActive(true);
    }

    public void ShowHomePage()
    {
        _homePage.gameObject.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
