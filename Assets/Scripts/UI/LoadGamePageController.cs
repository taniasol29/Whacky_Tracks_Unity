using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadGamePageController : MonoBehaviour
{
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _newPlayerButton;
    [SerializeField] private Button _goBackButton;

    public UnityEvent GoBackButtonClicked;
    public UnityEvent NewPlayerButtonClicked;
    public UnityEvent LoadGameButtonClicked;

    private void Awake()
    {
        _goBackButton.onClick.AddListener(OnClickGoBackButtton);
        _newPlayerButton.onClick.AddListener(OnClickNewPlayerButton);
        _loadGameButton.onClick.AddListener(OnClickLoadGameButton);
    }

    void OnClickGoBackButtton()
    {
        gameObject.SetActive(false);
        GoBackButtonClicked?.Invoke();
    }

    void OnClickNewPlayerButton()
    {
        gameObject.SetActive(false);
        NewPlayerButtonClicked?.Invoke();
    }

    private void OnClickLoadGameButton()
    {
        gameObject.SetActive(false);
        LoadGameButtonClicked?.Invoke();
    }
}
