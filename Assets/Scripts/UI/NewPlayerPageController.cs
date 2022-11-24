using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class NewPlayerPageController : MonoBehaviour
{
    public TMP_InputField _newPlayerName;
    public GameObject emptyFieldMessage;

    [SerializeField] private Button enterButton; // refaire avec des _HHHH
    [SerializeField] private Button goBackButton;

    public UnityEvent EnterButtonClicked;
    public UnityEvent GoBackButtonClicked;

    void OnClickGoBackButtton()
    {
        GoBackButtonClicked?.Invoke();
    }
    
    void OnClickEnterButtton()
    {
        // récupérer la valeur de l'input name
        string name = _newPlayerName.text;

        if (string.IsNullOrEmpty(name))
        {
            emptyFieldMessage.SetActive(true);
            //Debug.LogWarning("Veuillez saisir un nom"); // afficher element text à l'écran que le champs est vide 
        }
        else
        {
            emptyFieldMessage.SetActive(false);
            //lancer l'ordre de sauvegarde de nouvel utilisateur
            DataManager.Instance.NewPlayer(name);
            // déclanchement de passage à la page suivante
            EnterButtonClicked?.Invoke();
        }
    }

    void Awake()
    {
        emptyFieldMessage.SetActive(false);
        goBackButton.onClick.AddListener(OnClickGoBackButtton);
        enterButton.onClick.AddListener(OnClickEnterButtton);
    }

    void Update()
    {
        
    }
}
