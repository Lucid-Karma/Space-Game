using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : PlanetsBase
{
    //public ParticleSystem[] earthFlash;

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

    public override void UpdateScore()
    {
        point += 10;
        if(point >= 30)
            EventManager.OnScoreComplete.Invoke();
    }
}
