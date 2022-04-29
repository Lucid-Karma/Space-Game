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
            //for(int i = 0; i < 4; i++)
            //{
                UpdateScore();
                EventManager.OnPlanetDestroy.Invoke();
            //}
            /*
            for(int j = 0; j < 4; j++)
            {
                earthFlash[j].Play();
            }

            Destroy(gameObject);
            */
            

            PlanetCount -= 1;
            if (PlanetCount == 0)
            {
                EventManager.OnLevelSuccess.Invoke();
                Debug.Log("count is  " + PlanetCount);
            }
        }
    }

    public override void UpdateScore()
    {
        point += 10;
        Debug.Log("earth");
    }
}
