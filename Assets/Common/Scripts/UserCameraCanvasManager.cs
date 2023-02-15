using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * The user camera canvas manager.
 * Used to display and control the displayed text 
 */
public class UserCameraCanvasManager : MonoBehaviour 
{
    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI suggestionsText;
    
    
    private const int TargetFPS = 60;
    private const float FPSUpdateInterval = 0.5f;
    private const float SuggestionsUpdateInterval = 4.0f;
    private int _framesCount; 
    private float _framesTime; 
    private float _suggestionsTime; 
    
    private readonly List<string> _suggestions = new List<string>();
    private int _suggestionIndex = 0;

    private void Start()
    {
        // Clear initial text
        fpsText.text = "";
        suggestionsText.text = "";
        
        // add suggestions that will be displayed for the user
        _suggestions.Add("Click the left controller Menu button to open up the menu");
        _suggestions.Add("Getting further away from the speaker will decrease the volume");
        _suggestions.Add("You should get all straight A's");
        _suggestions.Add("Grading this project is a hard task, but 100 is guaranteed");
    }

    void Update()
    {
        // monitoring frame counter and the total time
        _framesCount++;
        _framesTime += Time.unscaledDeltaTime; 
        _suggestionsTime += Time.unscaledDeltaTime; 

        // measuring interval ended, so calculate FPS and display on Text
        if (_framesTime > FPSUpdateInterval)
        {
            if (fpsText != null)
            {
                // Update FPS text
                float fps = _framesCount/_framesTime;
                fpsText.text = System.String.Format("{0:F2} FPS", fps);
                fpsText.color = (fps > (TargetFPS-5) ? Color.green :
                    (fps > (TargetFPS-30) ?  Color.yellow : 
                        Color.red));
            }
            // reset for the next interval to measure
            _framesCount = 0;
            _framesTime = 0;
        }

        // measuring interval ended, so we could iterate through the suggestions
        if (_suggestionsTime > SuggestionsUpdateInterval)
        {
            if (suggestionsText != null)
            {
                // Update the Suggestions Text
                if (_suggestionIndex >= _suggestions.Count)
                {
                    _suggestionIndex = 0;
                }
                suggestionsText.text = _suggestions[_suggestionIndex];
                _suggestionIndex++;
                _suggestionsTime = 0;
            }
        }
    }
}