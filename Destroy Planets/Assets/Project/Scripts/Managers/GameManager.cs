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

/*
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
    */

    private void OnEnable()
    {
        EventManager.OnRestart.AddListener(ContinueGame);
        EventManager.OnLevelFail.AddListener(PauseGame);
        EventManager.OnLevelSuccess.AddListener(PauseGame);
        Timer.OnTimeOut += PauseGame;
    }
    private void OnDisable()
    {
        EventManager.OnRestart.RemoveListener(ContinueGame);
        EventManager.OnLevelFail.RemoveListener(PauseGame);
        EventManager.OnLevelSuccess.RemoveListener(PauseGame);
        Timer.OnTimeOut -= PauseGame;
    }

    void PauseGame()
    {
        StartCoroutine( WaitbeforePause() );
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator WaitbeforePause()
    {
        yield return new WaitForSeconds( 3.0f ); 
    }
}
