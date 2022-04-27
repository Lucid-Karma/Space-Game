using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnGameEnd.AddListener(HidePanel);
        EventManager.OnLevelFail.AddListener(HidePanel);
        Timer.OnTimeOut += HidePanel;
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(ShowPanel);
        EventManager.OnGameEnd.RemoveListener(HidePanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        Timer.OnTimeOut -= HidePanel;
    }
}
