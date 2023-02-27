using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static event Action onFinishedTasks;   
    private static GameManager _instance;
    private int _completedTaskCount = 0;
    private TrialLogger _trialLogger;

    void Awake()
    {
        if ( _instance != null && _instance != this )
        {
            Destroy(gameObject);
            return;
        }
 
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _trialLogger = GetComponent<TrialLogger>();
    }

    public static void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.StartGame:
                _instance.StartGame();
                break;
            case GameState.Escaped:
                _instance.Escaped();
                break;
            case GameState.Exit:
                _instance.ExitGame();
                break;
            case GameState.CompletedTask:
                _instance.CompletedTask();
                break;
            default:
                _instance.ExitGame();
                break;
        }
    }

    private void StartGame()
    {
        _completedTaskCount = 0;
        
        List<string> columnList = new List<string>
        {
            "firstTaskCompleteTimeSinceStart", 
            "secondTaskCompleteTimeSinceStart",
            "thirdTaskCompleteTimeSinceStart",
            "forthTaskCompleteTimeSinceStart",
        };
        _trialLogger.Initialize(Environment.UserName, columnList);
        SceneManager.LoadScene("Escape Room");
        _trialLogger.StartTrial();
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }

    private void Escaped()
    {
        ScoreManager.AddScore(Environment.UserName, Time.timeSinceLevelLoad);
        SceneManager.LoadScene("Enterance");
    }

    private void CompletedTask()
    {
        _completedTaskCount++;
        switch (_completedTaskCount)
        {
            case 1:
                _trialLogger.trial["firstTaskCompleteTimeSinceStart"] = Time.timeSinceLevelLoad.ToString();
                break;
            case 2:
                _trialLogger.trial["secondTaskCompleteTimeSinceStart"] = Time.timeSinceLevelLoad.ToString();
                break;
            case 3:
                _trialLogger.trial["thirdTaskCompleteTimeSinceStart"] = Time.timeSinceLevelLoad.ToString();
                break;
            case 4:
                _trialLogger.trial["forthTaskCompleteTimeSinceStart"] = Time.timeSinceLevelLoad.ToString();
                break;
        }
        
        if (_completedTaskCount == 4)
        {
            onFinishedTasks?.Invoke();
            _trialLogger.EndTrial();
        }
    }
    
    
}

public enum GameState
{
    StartGame,
    Escaped,
    Exit,
    CompletedTask
}
