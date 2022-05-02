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
        //EventManager.OnLevelFail.AddListener(InitializeBlurPanel);
        //EventManager.OnLevelSuccess.AddListener(InitializeBlurPanel);

        EventManager.OnLevelFail.AddListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
        Timer.OnTimeOut += InitializeLevelFailPanel;    //a big sus.
        //EventManager.OnLevelFinish.AddListener(HidePanel);

    }

    private void OnDisable()
    {
        //EventManager.OnLevelFail.RemoveListener(InitializeBlurPanel);
        //EventManager.OnLevelSuccess.RemoveListener(InitializeBlurPanel);

        EventManager.OnLevelFail.RemoveListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
        Timer.OnTimeOut -= InitializeLevelFailPanel;
        //EventManager.OnLevelFinish.RemoveListener(HidePanel);


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

    /*private void InitializeBlurPanel()
    {
        BlurPanel.ShowPanel();
        ShowPanel();
    }*/
}
