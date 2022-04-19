using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (SwitchCamera.isCamera1Active)
        {
            gameObject.SetActive(true);
        }
    }
    /*
    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnViewChange.AddListener(OnCrosshairAppear);
    }
    void OnDisable()
    {
        EventManager.OnViewChange.RemoveListener(OnCrosshairAppear);
    }
    void OnCrosshairAppear()
    {
        gameObject.SetActive(true);
    }
    */
}
