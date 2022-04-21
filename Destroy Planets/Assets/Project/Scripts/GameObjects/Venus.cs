using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venus : PlanetsBase
{
    /*public override void OnCollisionEnter()
    {
        Destroy(gameObject);
    }*/

    public override void UpdateScore()
    {
        point += 2;
        Debug.Log("Venus");
    }
}
