using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Class to inherit the traits that will be on every planet.
public abstract class PlanetsBase : MonoBehaviour
{
    public static int point = 0; // A static int variable to make ScorTXT access it.
    public static int PlanetCount = 4;

    /*private void OnEnable()
    {
        //EventManager.OnPlanetDestroy.AddListener(UpdateScore);
        EventManager.OnPreDestroy.AddListener(OnCollisionEnter);
    }

    private void OnDisable()
    {
        //EventManager.OnPlanetDestroy.RemoveListener(UpdateScore);
        EventManager.OnPreDestroy.RemoveListener(OnCollisionEnter);
    }

    public void OnSuccess()
    {
        UpdateScore();

        PlanetCount -= 1;
        if (PlanetCount == 0)
        {
            EventManager.OnLevelSuccess.Invoke();
            Debug.Log("count is  " + PlanetCount);
        }
    }*/

    // Default point as +1 but still changable coz it's virtual.
    public virtual void UpdateScore() 
    {
        point++;
    }

    //public abstract void OnCollisionEnter(); // This is gonna be change for every single planet cuz it's abstract.

    public void OnCollisionEnter()
    {
        UpdateScore();
        EventManager.OnPlanetDestroy.Invoke();

        Destroy(gameObject);

        PlanetCount -= 1;
        if (PlanetCount == 0)
        {
            EventManager.OnLevelSuccess.Invoke();
            Debug.Log("count is  " + PlanetCount);
        }
    }

}
