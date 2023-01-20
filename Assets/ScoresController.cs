using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresController : MonoBehaviour
{
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _scoreText;

    public TMP_Text Name { get => _name; set => _name = value; }
    public TMP_Text ScoreText { get => _scoreText; set => _scoreText = value; }
    
}
