using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void OnEnable() 
    {
        //onClick.AddListener(() => GameManager.Instance.EndGame());
        EventManager.OnGameStart.AddListener(Restart);
    }
    private void OnDisable() 
    {
        //onClick.RemoveListener(() => GameManager.Instance.EndGame());
        EventManager.OnGameStart.RemoveListener(Restart);    
    }
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        EventManager.OnRestart.Invoke();
    }
}
