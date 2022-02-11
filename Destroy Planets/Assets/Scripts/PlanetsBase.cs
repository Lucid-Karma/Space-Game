using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetsBase : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("bomb");
    }

    public abstract void OnCollisionEnter();
}
