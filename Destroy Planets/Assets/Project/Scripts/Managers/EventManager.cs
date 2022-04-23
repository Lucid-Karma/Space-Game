using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    public static UnityEvent OnViewChange = new UnityEvent();
    public static UnityEvent OnCamera00On = new UnityEvent();
    public static UnityEvent OnCamera01On = new UnityEvent();
    public static UnityEvent OnPlanetDestroy = new UnityEvent();
    public static UnityEvent OnPreDestroy = new UnityEvent();
}
