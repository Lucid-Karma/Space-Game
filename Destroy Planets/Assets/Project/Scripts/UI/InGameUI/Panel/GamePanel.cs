using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel
{
    public Panel LevelSuccesPanel;
    public Panel LevelFailPanel;

    private void Awake() 
    {
        LevelSuccesPanel.HidePanel();
        LevelFailPanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
        Timer.OnTimeOut += InitializeLevelFailPanel;    //a big sus.
        //EventManager.OnLevelFinish.AddListener(HidePanel);

    }

    private void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
        Timer.OnTimeOut -= InitializeLevelFailPanel;
        //EventManager.OnLevelFinish.RemoveListener(HidePanel);


    }

    private void InitializeLevelFailPanel()
    {
        LevelSuccesPanel.HidePanel();
        LevelFailPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeLevelSuccessPanel()
    {
        LevelSuccesPanel.ShowPanel();
        LevelFailPanel.HidePanel();
        ShowPanel();
    }
}
