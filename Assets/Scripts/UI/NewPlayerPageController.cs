using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class NewPlayerPageController : MonoBehaviour
{
    public TMP_InputField _newPlayerName;
    public GameObject _emptyFieldMessage;

    [SerializeField] private Button _enterButton; // refaire avec des _HHHH
    [SerializeField] private Button _goBackButton;

    public UnityEvent EnterButtonClicked;
    public UnityEvent GoBackButtonClicked;

    void OnClickGoBackButtton()
    {
        GoBackButtonClicked?.Invoke();
    }
    
    void OnClickEnterButtton()
    {
        // r�cup�rer la valeur de l'input name
        string name = _newPlayerName.text;

        if (string.IsNullOrEmpty(name))
        {
            _emptyFieldMessage.SetActive(true);
            //Debug.LogWarning("Veuillez saisir un nom"); // afficher element text � l'�cran que le champs est vide 
        }
        else
        {
            _emptyFieldMessage.SetActive(false);
            //lancer l'ordre de sauvegarde de nouvel utilisateur
            DataManager.Instance.NewPlayer(name);
            // d�clanchement de passage � la page suivante
            EnterButtonClicked?.Invoke();
        }
    }

    void Awake()
    {
        _emptyFieldMessage.SetActive(false);
        _goBackButton.onClick.AddListener(OnClickGoBackButtton);
        _enterButton.onClick.AddListener(OnClickEnterButtton);
    }
}
