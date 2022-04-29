using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KmPerHour : MonoBehaviour
{
    private TextMeshProUGUI kmText;
    public TextMeshProUGUI KMText
    {
        get
        {
            if(kmText == null)
            kmText = GetComponent<TextMeshProUGUI>();

            return kmText;
        }
    }

    private void FixedUpdate() 
    {
        UpdateKmText();
    }

    private void UpdateKmText()
    {
        //float oneMach = 1062.2f;
        float km = Player.thrust * 1062.2f;
        //float basemach = mach * Time.fixedDeltaTime;
        //ScoreText.text = "mach " + mach + player.position.z.ToString("0");
        KMText.text = km.ToString("0") + " KM/H";
    }
}
