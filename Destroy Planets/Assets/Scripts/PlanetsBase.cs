using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetsBase : MonoBehaviour
{
    public static int point = 1;
    public void OnMouseDown()
    {
        EventManager.OnPlanetDestroy.Invoke();
        UpdateScore();
    }

    public virtual void UpdateScore()
    {
        point++;
    }

    public abstract void OnCollisionEnter();
}
