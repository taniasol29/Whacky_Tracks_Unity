using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ChoosePlayerPageController : MonoBehaviour
{
    [SerializeField] private Button _goBackButton;
    [SerializeField] private ChoosePlayerElementController _choosePlayerElementPrefab;
    [SerializeField] private Transform _ChoosePlayerElementsContainer;

    public UnityEvent GoBackButtonClicked;
    public UnityEvent PlayerSelected;
    
    void Awake()
    {
        _goBackButton.onClick.AddListener(OnClickGoBackButton);
    }

    private void OnEnable()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
        //    choosePlayerElements.Text.text = $"PLAYER {i + 1}";
        //}

        // Récupérer la liste des players existants
        for(int i = 0; i < DataManager.Instance.AllPlayers.Count; i++)
        {
            var player = DataManager.Instance.AllPlayers[i];
            Debug.Log(player.Name);

            // Version 2
            // pour chaque player Initialiser un prefab avec nom, date et time
            DateTime date = DateTimeOffset.FromUnixTimeSeconds(player.LastConnection).LocalDateTime;
            var choosePlayerElements = Instantiate(_choosePlayerElementPrefab, _ChoosePlayerElementsContainer);
            choosePlayerElements.PlayerNameText.text = player.Name;
            choosePlayerElements.LastConnectionDateText.text = date.ToString("dddd, dd MMMM yyyy, hh:mm tt");

            choosePlayerElements.OnClickSelectPlayerButton.AddListener(CallPlayerSelected);
            choosePlayerElements.PlayerIndex = i;
        }
    }

    void OnClickGoBackButton()
    {
        gameObject.SetActive(false);
        GoBackButtonClicked?.Invoke();
    }

    private void CallPlayerSelected(int playerIndex)
    {
        DataManager.Instance.CurrentPlayer = DataManager.Instance.AllPlayers[playerIndex];
        PlayerSelected?.Invoke();
    }
}
