using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel
{
    public Panel LevelSuccesPanel;
    public Panel LevelFailPanel;
    public Panel BlurPanel;

    private void Awake() 
    {
        LevelSuccesPanel.HidePanel();
        LevelFailPanel.HidePanel();
        BlurPanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
        Timer.OnTimeOut += InitializeLevelFailPanel;    //a big sus.
    }

    private void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
        Timer.OnTimeOut -= InitializeLevelFailPanel;
    }

    private void InitializeLevelFailPanel()
    {
        LevelSuccesPanel.HidePanel();
        BlurPanel.ShowPanel();
        LevelFailPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeLevelSuccessPanel()
    {
        LevelSuccesPanel.ShowPanel();
        BlurPanel.ShowPanel();
        LevelFailPanel.HidePanel();
        ShowPanel();
    }
}
