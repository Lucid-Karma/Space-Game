using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : Button
{
    /*private void OnEnable() 
    {
        EventManager.OnGameEnd.AddListener(Quit);

    }
    private void OnDisable() 
    {
        EventManager.OnGameEnd.RemoveListener(Quit);
    }*/

    protected override void OnEnable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.AddListener(() => GameManager.Instance.EndGame());

    }

    protected override void OnDisable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.RemoveListener(() => GameManager.Instance.EndGame());

    }

/*    public void Quit()
    {
        Application.Quit();
    }*/
}
