using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : PlanetsBase
{
    public override void OnCollisionEnter()
    {
        Debug.Log("Earth");
        Destroy(gameObject);
    }

    public override void UpdateScore()
    {
        point += 10;
        Debug.Log("+10");
    }
}
