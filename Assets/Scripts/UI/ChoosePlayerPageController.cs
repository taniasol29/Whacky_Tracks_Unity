using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ChoosePlayerPageController : MonoBehaviour
{
    [SerializeField] private Button goBackButton;
    [SerializeField] private ChoosePlayerElementController _choosePlayerElementPrefab;
    [SerializeField] private Transform _ChoosePlayerElementsContainer;

    public UnityEvent GoBackButtonClicked;

    void OnClickGoBackButton()
    {
        GoBackButtonClicked?.Invoke();
    }
    
    void Awake()
    {
        goBackButton.onClick.AddListener(OnClickGoBackButton);
    }

    private void OnEnable()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
        //    choosePlayerElements.Text.text = $"PLAYER {i + 1}";
        //}

        // Récupérer la liste des players existants
        foreach (var player in DataManager.Instance.AllPlayers)
        {
            Debug.Log(player.Name);

            // Version 1
            // pour chaque player Initialiser un prefab avec nom, date et time
            System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            date = date.AddSeconds(player.LastConnection).ToLocalTime();
            var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
            choosePlayerElements.Text.text = $"{player.Name} - Last connection: {date.ToShortDateString()} at {date.ToShortTimeString()}";

            // Version 2
            // pour chaque player Initialiser un prefab avec nom, date et time
            //DateTime date = DateTimeOffset.FromUnixTimeSeconds(player.LastConnection).LocalDateTime;
            //var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
            //choosePlayerElements.Text.text = $"{player.Name} - Last connection: {date}";

            // Version 3
            // pour chaque player Initialiser un prefab avec nom, date et time
            //var offset = DateTimeOffset.FromUnixTimeSeconds(player.LastConnection);
            //var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
            //choosePlayerElements.Text.text = $"{player.Name} - Last connection: {offset.LocalDateTime}";
        }
    }
}
