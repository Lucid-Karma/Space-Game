using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public static Cameras Instance { get; private set; }
    public void switchCamera()
    {
        EventManager.OnViewChange.Invoke();
    }
}
