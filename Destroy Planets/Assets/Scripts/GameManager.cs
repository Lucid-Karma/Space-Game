using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*[System.Serializable]
    public class GameData
    {
        
    }*/

    private bool isGameStarted;
    //[ShowInInspector]
    //[ReadOnly]
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    //public GameData GameData = new GameData();

    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }
}
