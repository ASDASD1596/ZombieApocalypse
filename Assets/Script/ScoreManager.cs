using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score = 0;
    public TMP_Text scoreDisplay;
    
    public void AddScore(int value)
    {
        Score += value;
        
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        scoreDisplay.text = Score.ToString();
    }
}
