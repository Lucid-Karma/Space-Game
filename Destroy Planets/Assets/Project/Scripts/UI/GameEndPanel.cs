using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
using UnityEngine.UI;

public class GameEndPanel : Panels
{
    //private GameObject levelFailPanel;
    public GameObject LevelFailPanel; //{ get { return (levelFailPanel == null) ? levelFailPanel = GetComponent<GameObject>() : levelFailPanel; } }

    private void OnEnable() 
    {
        EventManager.OnLevelFail.AddListener(ShowPanel);
    }
    private void OnDisable() 
    {
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
    }
    /*public void EndGame()
    {
        LevelFailPanel.gameObject.SetActive(true);
        Debug.Log("over");
    }*/

    public override void ShowPanel()
    {
        LevelFailPanel.gameObject.SetActive(true);
    }
}
