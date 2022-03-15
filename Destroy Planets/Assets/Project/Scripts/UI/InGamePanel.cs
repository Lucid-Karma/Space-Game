using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanel : Panels
{
    //private GameObject levelContunie;
    public GameObject LevelContunie; //{ get { return (levelContunie == null) ? levelContunie = GetComponent<GameObject>() : levelContunie; } }

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
    }
    private void OnDisable() 
    {
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
    }

    /*public void StartLevelUI()
    {
        LevelContunie.gameObject.SetActive(true);
    }
    public void EndLevelUI()
    {
        LevelContunie.gameObject.SetActive(false);
    }*/

    public override void ShowPanel()
    {
        LevelContunie.gameObject.SetActive(true);
    }
    public override void HidePanel()
    {
        LevelContunie.gameObject.SetActive(false);
    }
}
