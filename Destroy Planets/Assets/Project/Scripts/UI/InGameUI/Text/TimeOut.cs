using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : Panel
{
    private Panel timeOutTXT;

    void Awake()
    {
        timeOutTXT = this;
        timeOutTXT.HidePanel();
    }
    void OnEnable()
    {
        Timer.OnTimeOut += ShowPanel;
    }
    void OnDisable()
    {
        Timer.OnTimeOut -= ShowPanel;
    }
}
