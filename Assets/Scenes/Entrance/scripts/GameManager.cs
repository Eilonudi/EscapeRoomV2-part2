using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static event Action onFinishedTasks;   
    private static GameManager _instance;
    private static int _completedTaskCount = 0;

    void Awake()
    {   
        if (GameManager._instance == null) 
        {
            GameManager._instance = this;
        }        
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
        SceneManager.LoadScene("Escape Room");
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
        Debug.Log("num of completed tasks - " + _completedTaskCount);
        if (_completedTaskCount == 4)
        {
            onFinishedTasks?.Invoke();
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
