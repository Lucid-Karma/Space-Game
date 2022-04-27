using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{ /*
    private void OnEnable() 
    {
        //onClick.AddListener(() => GameManager.Instance.EndGame());
        EventManager.OnGameEnd.AddListener(Finish);
    }
    private void OnDisable() 
    {
        //onClick.RemoveListener(() => GameManager.Instance.EndGame());
        EventManager.OnGameEnd.RemoveListener(Finish);    
    }
    */
    public void Finish()
    {
        Application.Quit();
        Debug.Log("It's gonna work when you build and run the game.");
    }
}
