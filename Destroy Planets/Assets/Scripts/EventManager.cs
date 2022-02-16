using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    public static UnityEvent OnViewChange = new UnityEvent();
    public static UnityEvent OnPlanetDestroy = new UnityEvent();
    public static UnityEvent OnTargeting = new UnityEvent();
}
