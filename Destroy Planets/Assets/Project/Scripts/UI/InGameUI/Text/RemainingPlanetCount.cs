using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemainingPlanetCount : MonoBehaviour
{
    private TextMeshProUGUI plText;
    public TextMeshProUGUI PlText
    {
        get
        {
            if(plText == null)
            plText = GetComponent<TextMeshProUGUI>();

            return plText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(UpdatePlText);
        //EventManager.OnGameStart.AddListener(RecreateScore);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdatePlText);
        //EventManager.OnGameStart.RemoveListener(RecreateScore); 
    }

    public int planetCount = 0;
    private void UpdatePlText()
    {
        planetCount = PlanetsBase.PlanetCount;
        PlText.text = planetCount + " PL";
    }
}
