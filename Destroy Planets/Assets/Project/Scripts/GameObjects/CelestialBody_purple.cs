using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody_purple : PlanetsBase
{
    public override void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "bullet")
        {
            
            UpdateScore();
            EventManager.OnPlanetDestroy.Invoke();
            
            PlanetCount -= 1;
            if (PlanetCount == 0)
            {
                EventManager.OnLevelSuccess.Invoke();
            }
        }
    }

}
