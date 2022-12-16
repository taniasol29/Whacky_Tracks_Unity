using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class NewPlayerPageController : MonoBehaviour
{
    public TMP_InputField _newPlayerName;
    public GameObject _emptyFieldMessage;
    private const int MAX_CHAR_NB = 15;

    [SerializeField] private Button _enterButton; 
    [SerializeField] private Button _goBackButton;

    public UnityEvent EnterButtonClicked;
    public UnityEvent GoBackButtonClicked;

    void Awake()
    {
        _emptyFieldMessage.SetActive(false);
        _goBackButton.onClick.AddListener(OnClickGoBackButtton);
        _enterButton.onClick.AddListener(OnClickEnterButtton);
        _newPlayerName.onValueChanged.AddListener(OnPlayerNameInputChange);
    }

    void OnClickGoBackButtton()
    {
        GoBackButtonClicked?.Invoke();
    }

    private void OnPlayerNameInputChange(string arg0)
    {
        if (arg0.Length > MAX_CHAR_NB) _newPlayerName.text = arg0.Substring(0, MAX_CHAR_NB);
    }
    
    void OnClickEnterButtton()
    {
        // récupérer la valeur de l'input name
        string name = _newPlayerName.text;

        if (string.IsNullOrEmpty(name))
        {
            _emptyFieldMessage.SetActive(true);
            //Debug.LogWarning("Veuillez saisir un nom"); // afficher element text à l'écran que le champs est vide 
        }
        else
        {
            _emptyFieldMessage.SetActive(false);
            //lancer l'ordre de sauvegarde de nouvel utilisateur
            DataManager.Instance.NewPlayer(name);
            // déclanchement de passage à la page suivante
            gameObject.SetActive(false);
            EnterButtonClicked?.Invoke();
        }
    }
}
