using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoresPageController : MonoBehaviour
{
    [SerializeField] private Button _goBackButton;
    [SerializeField] private ScoresController _scorePrefab;
    [SerializeField] private Transform _scoresContainer;

    public UnityEvent GoBackButtonClicked;

    private void Awake()
    {
        _goBackButton.onClick.AddListener(OnClickGoBackButtton);
    }

    private void Start()
    {
        //var player = DataManager.Instance.CurrentPlayer;
        //var scores = ScoresManager.Instance.Score;

        Dictionary<string, int> PlayersByMaxScores = new Dictionary<string, int>();
        foreach (var p in DataManager.Instance.AllPlayers)
        {
            var maxScore = p.Scores.Max();
            PlayersByMaxScores.Add(p.Name, maxScore);
        }

        // Trier le dictionnaire par score descendant
        //PlayersByMaxScores.OrderBy<>

        foreach(var playerMaxScore in PlayersByMaxScores)
        {
            var score = Instantiate(_scorePrefab, _scoresContainer);
            score.Name.text = playerMaxScore.Key;
            score.ScoreText.text = playerMaxScore.Value.ToString();
        }
    }

    void OnClickGoBackButtton()
    {
        gameObject.SetActive(false);
        GoBackButtonClicked?.Invoke();
    }
}
