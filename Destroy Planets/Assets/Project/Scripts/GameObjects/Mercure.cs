using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercure : PlanetsBase
{
    public override void UpdateScore()
    {
        point += 6;
        if(point >= 30)
            EventManager.OnScoreComplete.Invoke();
    }
}
