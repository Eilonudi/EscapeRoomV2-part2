using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Helper class to store the Score data
 */
[Serializable]
public class Score
{
    public string name;
    public float time;

    public Score(string name, float time)
    {
        this.name = name;
        this.time = time;
    }   
}
