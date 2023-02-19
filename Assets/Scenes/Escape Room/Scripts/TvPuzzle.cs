using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class TvPuzzle : MonoBehaviour
{
    [Range(1000, 9999)]
    public int puzzleChannel = 5655;
    
    [Range(1000, 9999)]
    public int teacherCode = 4444;
    
    public TextMeshProUGUI channelText;
    public TextMeshProUGUI puzzleAnswerText;
    
    private readonly List<int> _enteredNumbers = new List<int>();
    private bool _solved = false;
    private VideoPlayer _tvVideo;
    
    void Start()
    {
        // clear channel and answer text
        channelText.text = "";
        puzzleAnswerText.text = "";
        _tvVideo = GetComponentInChildren<VideoPlayer>();
    }
    
    public void SetChannelNumber(int enteredNum)
    {
        if (!_solved)
        {
            _enteredNumbers.Add(enteredNum);
            var numbersString = "";
        
            for (int j = 4 -_enteredNumbers.Count; j > 0; j--)
            {
                numbersString += "_ ";
            }
        
            for (int i = 0; i < _enteredNumbers.Count; i++)
            {
                numbersString += _enteredNumbers[i].ToString() + " ";
            }
            channelText.text = numbersString;

            CheckIfSolved(numbersString);
        }
        
    }

    private void CheckIfSolved(string numbersString)
    {
        if (_enteredNumbers.Count == 4)
        {
            var clearedNumberString = Regex.Replace(numbersString, @"\s+", "");
            var channel = Int32.Parse(clearedNumberString);
            if (channel == puzzleChannel)
            {
                _solved = true;
                ShowSolution();
            }
            else
            {
                channelText.text = "";
                _enteredNumbers.Clear();
            }
        }
    }
    
    private void ShowSolution()
    {
        channelText.text = "";
        _tvVideo.Stop();
        puzzleAnswerText.text = "Course code is \n " + teacherCode;
    }
}
