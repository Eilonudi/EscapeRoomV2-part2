
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * ScoreData is a Serializable class that let's us store the score list
 * we use it to load and save scores as a JSON string
 */
[Serializable]
public class ScoreData
{
    public List<Score> scores;

    public ScoreData()
    {
        scores = new List<Score>();
    }
}

/**
 * ScoreManager handles all the scores for the users. 
 */
public class ScoreManager : MonoBehaviour
{
    public ScoreData scoreData;
    private static ScoreManager _instance;

    private const string ScoresStorageKey = "PlayersScores";
    
    public static void AddScore(Score score)
    {
        _instance.scoreData.scores.Add(score);
    }

    public static void AddScore(string name, double timeSinceStart)
    {
        _instance.scoreData.scores.Add(new Score(name, (int)timeSinceStart));
        _instance.SaveScores();
    }
    
    public IOrderedEnumerable<Score> GetOrderedScores()
    {
        return scoreData.scores.OrderBy(record => record.time);
    }
    
    public void SaveScores()
    {
        var jsonScores = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString(ScoresStorageKey, jsonScores);
    }

    private void Awake()
    {
        var jsonScores = PlayerPrefs.GetString(ScoresStorageKey, "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(jsonScores);
        if (_instance == null)
        {
            _instance = this;    
        }
    }

    private void OnDestroy()
    {
        SaveScores();
    }
    
}
