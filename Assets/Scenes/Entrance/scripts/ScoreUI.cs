using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/**
 * Manages the UI of the score board
 * Adding rows of scores
 */
public class ScoreUI : MonoBehaviour
{
    [Range(1, 4)]
    public float iterationRate = 1.0f;
    public ScoreManager scoreManager;
    public TextMeshProUGUI placeText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    private List<Score> _scores;
    private int _activeScoreIndex = 0;

    void Start()
    {
        scoreManager.AddScore(new Score("udi", 153));
        scoreManager.AddScore(new Score("Noam", 153));
        scoreManager.AddScore(new Score("Shelly", 153));
        
        // Clean the active text
        placeText.text = "";
        nameText.text = "";
        scoreText.text = "";

        _scores = scoreManager.GetOrderedScores().Take(3).ToList();
        InvokeRepeating("UpdateScore", 0, iterationRate);
    }

    void UpdateScore()
    {
        if (_activeScoreIndex > _scores.Count || _activeScoreIndex > 2)
        {
            _activeScoreIndex = 0;
        }
        
        var score = _scores[_activeScoreIndex];
        placeText.text = "#" + (_activeScoreIndex+1).ToString();
        nameText.text = score.name;
        scoreText.text = score.time.ToString();

        _activeScoreIndex++;
    }
}
