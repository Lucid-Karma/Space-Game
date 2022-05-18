using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MachController : MonoBehaviour
{
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

    private void FixedUpdate() 
    {
        UpdateMachText();
    }

    private void UpdateMachText()
    {
        float mach = Player.thrust;
        MachText.text = "MACH " + mach.ToString("0");
    }
}
