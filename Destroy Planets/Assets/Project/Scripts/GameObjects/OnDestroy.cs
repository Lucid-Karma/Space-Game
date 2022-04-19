using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDestroy : MonoBehaviour
{
    public void OnShoot()
    {
        EventManager.OnPlanetDestroy.Invoke();
    }
}
