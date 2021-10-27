using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Score : Singleton<Score>
{
    public int scorePoint = 0;
    public TMP_Text ScoreText;

    void Start()
    {
        ScoreText.text = "Score: " + scorePoint;
    }
    private void Update()
    {
        ScoreText.text = "Score: " + scorePoint;
    }
}
