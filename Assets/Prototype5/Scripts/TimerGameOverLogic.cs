using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerGameOverLogic : MonoBehaviour
{
    int countDownStartValue = 5;
    public TMP_Text timerUI;
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            Debug.Log("Timer : " + countDownStartValue);
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Debug.Log("GameOver!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
