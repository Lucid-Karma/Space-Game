using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars : PlanetsBase
{
    /*public override void OnCollisionEnter()
    {
        Destroy(gameObject);
    }*/

    public override void UpdateScore()
    {
        point += 2;
        if(point >= 30)
            EventManager.OnScoreComplete.Invoke();
    }
}
