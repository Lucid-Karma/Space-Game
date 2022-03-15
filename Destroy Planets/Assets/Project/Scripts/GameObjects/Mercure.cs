using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercure : PlanetsBase
{
    public override void OnCollisionEnter()
    {
        Debug.Log("Mercure");
        Destroy(gameObject);
    }
}
