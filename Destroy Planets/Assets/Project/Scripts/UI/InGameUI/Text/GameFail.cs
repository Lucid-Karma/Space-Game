using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFail : Panel
{
    private Panel gameFailTXT;

    void Awake()
    {
        gameFailTXT = this;
        gameFailTXT.HidePanel();
    }
    void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(ShowPanel);
    }
    void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
    }
}
