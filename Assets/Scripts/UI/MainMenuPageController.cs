using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuPageController : MonoBehaviour
{
    [SerializeField] private Button _extrasButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TMP_Text _welcomeTexte;

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
        _quitButton.onClick.AddListener(OnQuitButton);
        _playButton.onClick.AddListener(OnPlayButton);
    }

    private void OnEnable()
    {
        _welcomeTexte.text = $"Welcome {DataManager.Instance.CurrentPlayer.Name}";
    }
}
