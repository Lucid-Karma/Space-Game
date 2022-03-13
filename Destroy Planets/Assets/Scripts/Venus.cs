using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venus : PlanetsBase
{
    public override void OnCollisionEnter()
    {
        Debug.Log("Venus");
        Destroy(gameObject);
    }

    public override void UpdateScore()
    {
        point += 2;
    }
}
