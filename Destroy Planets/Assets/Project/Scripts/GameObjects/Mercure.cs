using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercure : PlanetsBase
{
    /*public override void OnCollisionEnter()
    {
        Destroy(gameObject);
    }*/

    public override void UpdateScore()
    {
        point += 6;
        Debug.Log("mercure");
    }
}
