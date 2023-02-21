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
    public double time;

    public Score(string name, double time)
    {
        this.name = name;
        this.time = time;
    }   
}
