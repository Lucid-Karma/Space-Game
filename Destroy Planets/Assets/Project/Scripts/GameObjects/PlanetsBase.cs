using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Class to inherit the traits that will be on every planet.
public abstract class PlanetsBase : MonoBehaviour
{
    public static int point = 0; // A static int variable to make ScorTXT access it.
    public static int PlanetCount = 25;
    public static bool isLevelSuccessed = false;


    // Default point as +1 but still changable coz it's virtual.
    public virtual void UpdateScore() 
    {
        point++;

        if(point >= 29)
            EventManager.OnScoreComplete.Invoke();
    }

    /*public void UpdatePlanetCount()
    {
        PlanetCount -= 1;
        if (PlanetCount == 0)
        {
            EventManager.OnLevelSuccess.Invoke();
            isLevelSuccessed = true;
            Debug.Log("true");
        }
    }*/

    //public abstract void OnCollisionEnter(); // This is gonna be change for every single planet cuz it's abstract.

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            UpdateScore();
            
            PlanetCount -= 1;
            if (PlanetCount == 0)
            {
                EventManager.OnLevelSuccess.Invoke();
                isLevelSuccessed = true;
            }

            EventManager.OnPlanetDestroy.Invoke();

            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnRestart.AddListener(Reset);
    }

    private void OnDisable()
    {
        EventManager.OnRestart.RemoveListener(Reset);
    }

    public void Reset()
    {
        point = 0;
        PlanetCount = 25;
        isLevelSuccessed = false;
    }

}
