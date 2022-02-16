using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject[] uı;
    //public GameObject DestroyPanel;
    private int counter = 0;

    void Awake()
    {
        for (int i = 0; i < uı.Length; i++)
        {
            uı[i].SetActive(false);
        }

        uı[counter].SetActive(true);
    }

    private void OnEnable()
    {
        EventManager.OnTargeting.AddListener(OnUIChange);
    }

    private void OnDisable()
    {
        EventManager.OnTargeting.RemoveListener(OnUIChange);
    }

    public void OnUIChange()
    {
        uı[counter].SetActive(false);
        counter++;
        if (counter >= uı.Length)
        {
            counter = 0;
        }

        uı[counter].SetActive(true);
    }
}
