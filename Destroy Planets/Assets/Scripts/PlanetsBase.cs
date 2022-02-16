using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetsBase : MonoBehaviour
{
    public static int point = 0;
    public void OnMouseDown()
    {
        EventManager.OnPlanetDestroy.Invoke();
        UpdateScore();
        Debug.Log("bomb");
    }

    public abstract void UpdateScore();

    public abstract void OnCollisionEnter();
}
