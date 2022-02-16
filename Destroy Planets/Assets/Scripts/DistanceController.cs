using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{
    private Text distanceText;
    public Text DistanceText
    {
        get
        {
            if(distanceText == null)
            distanceText = GetComponent<Text>();

            return distanceText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnTargeting.AddListener(UpdateDistance);
    }

    private void OnDisable()
    {
        EventManager.OnTargeting.RemoveListener(UpdateDistance);
    }

    private void UpdateDistance()
    {
        //if (Player.offset <= 2000f)
        //{
            float dist = 2000f;
            DistanceText.text = "Distance <= " + dist;
        //}
    }
}
