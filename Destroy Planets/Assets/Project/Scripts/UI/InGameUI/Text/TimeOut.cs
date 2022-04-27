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
        EventManager.OnTimeOut.AddListener(ShowPanel);
    }
    void OnDisable()
    {
        EventManager.OnTimeOut.RemoveListener(ShowPanel);
    }
}
