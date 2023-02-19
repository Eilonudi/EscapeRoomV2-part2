using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TvPuzzle : MonoBehaviour
{
    public TextMeshProUGUI channelText;
    
    private readonly List<int> _enteredNumbers = new List<int>();
    
    void Start()
    {
        // clear channel text
        channelText.text = "";
        SetChannelNumber(1);
        SetChannelNumber(3);
    }

    
    void Update()
    {
        
    }

    void SetChannelNumber(int enteredNum)
    {
        _enteredNumbers.Add(enteredNum);
        // only 3 numbers are allowed
        if (_enteredNumbers.Count > 3)
        {
            _enteredNumbers.Clear();
        };
        
        var numbersString = "";
        
        for (int j = 3 -_enteredNumbers.Count; j > 0; j--)
        {
            numbersString += "_ ";
        }
        
        for (int i = 0; i < _enteredNumbers.Count; i++)
        {
            numbersString += _enteredNumbers[i].ToString() + " ";
        }

        

        channelText.text = numbersString;
    }
}
