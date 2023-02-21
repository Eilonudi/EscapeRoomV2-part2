using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class MashovPuzzle : MonoBehaviour
{
    [Range(1000, 9999)]
    public int teacherCode = 44444;
    
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI codeText;
    
    private readonly List<int> _enteredNumbers = new List<int>();
    private bool _solved = false;
    

    public void EnterCode(int enteredNum)
    {
        if (!_solved)
        {
            _enteredNumbers.Add(enteredNum);
            var numbersString = "";
        
            for (int j = 5 -_enteredNumbers.Count; j > 0; j--)
            {
                numbersString += "_ ";
            }
        
            for (int i = 0; i < _enteredNumbers.Count; i++)
            {
                numbersString += _enteredNumbers[i].ToString() + " ";
            }
            codeText.text = numbersString;

            CheckIfSolved(numbersString);
        }
        
    }
    
    private void CheckIfSolved(string numbersString)
    {
        if (_enteredNumbers.Count == 5)
        {
            var clearedNumberString = Regex.Replace(numbersString, @"\s+", "");
            var enteredCode = Int32.Parse(clearedNumberString);
            if (enteredCode == teacherCode)
            {
                _solved = true;
                codeText.text = "";
                descriptionText.text = "It's done \n start vacation mode";
                GameManager.UpdateGameState(GameState.CompletedTask);
            }
            else
            {
                codeText.text = "_ _ _ _ _";
                descriptionText.text = "Wrong code \n try again";
                _enteredNumbers.Clear();
            }
        }
    }
}
