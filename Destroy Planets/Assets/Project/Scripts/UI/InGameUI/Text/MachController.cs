using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MachController : MonoBehaviour
{
    //public Transform player;

    private TextMeshProUGUI machText;
    public TextMeshProUGUI MachText
    {
        get
        {
            if(machText == null)
            machText = GetComponent<TextMeshProUGUI>();

            return machText;
        }
    }
/*
    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(UpdateMachText);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdateMachText);
    }*/

    private void FixedUpdate() 
    {
        UpdateMachText();
    }

    private void UpdateMachText()
    {
        float mach = Player.thrust;
        //float basemach = mach * Time.fixedDeltaTime;
        //ScoreText.text = "mach " + mach + player.position.z.ToString("0");
        MachText.text = "MACH " + mach.ToString("0");
    }
}
