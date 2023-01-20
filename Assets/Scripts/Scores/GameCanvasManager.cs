using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    void Update()
    {
        _score.text = $"Score: {ScoresManager.Instance.Score}";
    }
}
