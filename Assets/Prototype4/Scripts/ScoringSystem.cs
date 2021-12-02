using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoringSystem : Singleton<ScoringSystem>
{
    public TMP_Text ScoreText;
    public int theScore;
    //public AudioSource collectSound;

    public void AddScore(int score)
    {
        //collectSound.Play();
        theScore += score;
        ScoreText.text = "SCORE:" + theScore;
        
    }
}
