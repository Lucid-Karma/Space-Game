using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : PlanetsBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollisionEnter()
    {
        Debug.Log("touched");
    }

    public override void UpdateScore(int point)
    {
        point++;
    }
}
