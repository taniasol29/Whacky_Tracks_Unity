using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoosePlayerElementController : MonoBehaviour
{
    [SerializeField] TMP_Text _playerNameText;
    [SerializeField] TMP_Text _lastConnectionDateText;

    [SerializeField] private Button _selectPlayerButton;

    public UnityEvent<int> OnClickSelectPlayerButton;
    private int playerIndex = -1;

    private void Awake()
    {
        _selectPlayerButton.onClick.AddListener(OnPlayerSelected);
    }

    private void OnPlayerSelected()
    {
        gameObject.SetActive(false);
        OnClickSelectPlayerButton?.Invoke(PlayerIndex);
    }

    public TMP_Text PlayerNameText { get => _playerNameText; set => _playerNameText = value; }
    public TMP_Text LastConnectionDateText { get => _lastConnectionDateText; set => _lastConnectionDateText = value; }
    public int PlayerIndex { get => playerIndex; set => playerIndex = value; }
}
