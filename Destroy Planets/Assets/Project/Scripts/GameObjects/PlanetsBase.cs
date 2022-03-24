using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetsBase : MonoBehaviour
{
    public static int point = 0;
    public static int PlanetCount = 4;
    public void OnMouseDown()
    {
        UpdateScore();
        EventManager.OnPlanetDestroy.Invoke();
        PlanetCount -= 1;
        if (PlanetCount == 0)
        {
            EventManager.OnLevelSuccess.Invoke();
        }
    }

    public virtual void UpdateScore()
    {
        point++;
    }

    public abstract void OnCollisionEnter();
}
