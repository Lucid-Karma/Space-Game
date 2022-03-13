using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.OnLevelFail.AddListener(EndGame);
    }
    private void OnDisable() 
    {
        EventManager.OnLevelFail.RemoveListener(EndGame);
    }
    public void EndGame()
    {
        gameObject.SetActive(true);
    }
}
