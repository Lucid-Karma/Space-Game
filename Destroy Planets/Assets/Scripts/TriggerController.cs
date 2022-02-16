using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject[] uı;
    //public GameObject DestroyPanel;
    public void OnTriggerEnter(Collider other)
    {
        uı[0].SetActive(false);
        uı[1].SetActive(true);
    }
}
