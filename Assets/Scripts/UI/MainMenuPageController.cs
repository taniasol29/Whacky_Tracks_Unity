using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuPageController : MonoBehaviour
{
    [SerializeField] private Button extrasButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;

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
}
