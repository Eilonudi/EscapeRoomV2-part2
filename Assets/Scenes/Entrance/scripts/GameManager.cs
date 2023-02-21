using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static event Action onFinishedTasks;   
    private static GameManager _instance;
    private static double _startTime;
    private static int _completedTaskCount = 0;

    void Awake()
    {
        _instance = this;
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
        _startTime = Time.deltaTime;
        SceneManager.LoadScene("Escape Room");
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }

    private void Escaped()
    {
        var name = Environment.UserName;
        Debug.Log(_startTime - Time.deltaTime);
        ScoreManager.AddScore(name, Time.deltaTime, _startTime);
        SceneManager.LoadScene("Enterance");
    }

    private void CompletedTask()
    {
        _completedTaskCount++;
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
