using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : JMC
{
    public int lastRoundScore = 100;
    public int thisRoundScore = 170;
    public int lives = 5;

    
    

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver(lives))
            CheckScore();
        
    }

    void CheckScore()
    {
        Debug.Log("Score difference is " + PercentageChange(lastRoundScore, thisRoundScore).ToString("F2") + "%");
    }
}
