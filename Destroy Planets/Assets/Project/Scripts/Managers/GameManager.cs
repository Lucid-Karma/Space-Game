using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    public void StartGame()
    {
        if (IsGameStarted || applicationIsQuitting == false)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted || applicationIsQuitting == true)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }

    private void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(StopGame);
        EventManager.OnPlanetDestroy.AddListener(SlowMotion);
    }
    private void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(StopGame); 
        EventManager.OnPlanetDestroy.RemoveListener(SlowMotion);   
    }

    void StopGame()
    {

    }

// make sth. to make time scale normal.
    void SlowMotion()
    {
        Time.timeScale = 0.5f; //makes time scale 50% slower. 
    }
}
