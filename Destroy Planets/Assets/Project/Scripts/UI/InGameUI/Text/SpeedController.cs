using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedController : MonoBehaviour
{
    //public Transform player;

    private TextMeshProUGUI speedText;
    public TextMeshProUGUI SpeedText
    {
        get
        {
            if(speedText == null)
            speedText = GetComponent<TextMeshProUGUI>();

            return speedText;
        }
    }
/*
    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(UpdateSpeedText);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdateSpeedText);
    }*/

    private void FixedUpdate() 
    {
        UpdateSpeedText();
    }

    private void UpdateSpeedText()
    {
        float speed = Player.thrust;
        //float baseSpeed = speed * Time.fixedDeltaTime;
        //ScoreText.text = "Speed " + speed + player.position.z.ToString("0");
        SpeedText.text = "SPEED " + speed.ToString("0");
    }
}
