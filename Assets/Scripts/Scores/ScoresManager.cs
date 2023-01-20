using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoresManager 
{
    private int _score = 0;
    private static ScoresManager _instance = null;

    public Action OnTileSuccessTrigger;

    public static ScoresManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ScoresManager();
            return _instance;
        }

        private set => _instance = value;
    }

    public int Score { get => _score; set => _score = value; } //TS

    private ScoresManager() 
    {
        OnTileSuccessTrigger += ScoreUp;
    }

    ~ScoresManager()
    {
        OnTileSuccessTrigger -= ScoreUp;
    }

    public void HandleGameOver()
    {
        DataManager.Instance.CurrentPlayer.AddScore(Score);
        DataManager.Instance.CurrentPlayer.ShowScores();

        ResetScore();
    }

    public void ResetScore()
    {
        Score = 0;
    }
    
    public void ScoreUp()
    {
        Score += 100;
    }
}
