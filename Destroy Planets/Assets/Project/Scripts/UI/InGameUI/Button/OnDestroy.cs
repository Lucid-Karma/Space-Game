using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDestroy : Panel
{
    void Awake()
    {
        HidePanel();
    }

    void OnEnable()
    {
        EventManager.OnCamera00On.AddListener(HidePanel);
        EventManager.OnCamera01On.AddListener(ShowPanel);
    }
    void OnDisable()
    {
        EventManager.OnCamera00On.RemoveListener(ShowPanel);
        EventManager.OnCamera01On.RemoveListener(ShowPanel);
    }
    public void OnShoot() // invoked in Unity's OnClick.
    {
        EventManager.OnPreDestroy.Invoke();
        if(AudioManager.isSoundOn)
            FindObjectOfType<AudioManager>().Play("ShootingFX");
    }
}
