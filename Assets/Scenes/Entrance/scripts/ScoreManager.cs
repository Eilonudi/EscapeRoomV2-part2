
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

    public static void AddScore(string name, double startTimeInMilliseconds, double endTimeInMilliseconds)
    {
        _instance.scoreData.scores.Add(new Score(name, endTimeInMilliseconds - startTimeInMilliseconds));
    }

    public void ClearScores()
    {
        PlayerPrefs.SetString(ScoresStorageKey, "{}");
    }

    public IOrderedEnumerable<Score> GetOrderedScores()
    {
        return scoreData.scores.OrderByDescending(record => record.time);
    }

    private void Awake()
    {
        var jsonScores = PlayerPrefs.GetString(ScoresStorageKey, "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(jsonScores);
        _instance = this;
        ClearScores();
    }

    private void OnDestroy()
    {
        SaveScores();
    }
    
    private void SaveScores()
    {
        var jsonScores = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString(ScoresStorageKey, jsonScores);
    }
    
}
