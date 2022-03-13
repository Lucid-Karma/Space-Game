using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars : PlanetsBase
{
    public override void OnCollisionEnter()
    {
        Debug.Log("Mars");
        Destroy(gameObject);
    }

    public override void UpdateScore()
    {
        point += 2;
    }
}
