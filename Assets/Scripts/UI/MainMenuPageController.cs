using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuPageController : MonoBehaviour
{
    [SerializeField] private Button extrasButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text welcomeTexte;

    public UnityEvent QuitButtonClicked;
    public UnityEvent PlayButtonClicked;

    void OnQuitButton()
    {
        QuitButtonClicked?.Invoke();
    }

    private void OnPlayButton()
    {
        PlayButtonClicked?.Invoke();
    }

    private void Awake()
    {
        quitButton.onClick.AddListener(OnQuitButton);
        playButton.onClick.AddListener(OnPlayButton);
    }

    private void OnEnable()
    {
        welcomeTexte.text = $"Welcome {DataManager.Instance.CurrentPlayer.Name}";
    }

    private void OnDisable()
    {
        
    }
}
