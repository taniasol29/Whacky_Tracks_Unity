using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HomePageController : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public UnityEvent StartButtonClicked;
    
    void OnClickStartButton()
    {
        gameObject.SetActive(false);
        StartButtonClicked?.Invoke();
    }

    private void Awake()
    {
        _startButton.onClick.AddListener(OnClickStartButton); // relier la fonction à l'évènement onClick du bouton
    }
}