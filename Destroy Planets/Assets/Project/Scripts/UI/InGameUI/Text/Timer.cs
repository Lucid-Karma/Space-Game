using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    public TextMeshProUGUI TimerText
    {
        get
        {
            if(timerText == null)
            timerText = GetComponent<TextMeshProUGUI>();

            return timerText;
        }
    }

    public static Action OnTimeOut;
    public float timeValue = 90;

    void FixedUpdate()
    {
        if(timeValue > 0)   timeValue -= Time.fixedDeltaTime;
        else    timeValue = 0;

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)   timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        //if(timeToDisplay == 0)  Time.timeScale=0;

        //if(timeToDisplay == 0)  OnTimeOut?.Invoke();
    }
}
