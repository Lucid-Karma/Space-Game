using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    public Transform player;

    private Text speedText;
    public Text SpeedText
    {
        get
        {
            if(speedText == null)
            speedText = GetComponent<Text>();

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
/*
    private void Update() 
    {
        UpdateSpeedText();
    }

    private void UpdateSpeedText()
    {
        float speed = Player.forwardForce;
        float baseSpeed = speed + player.position.z / 100;
        //ScoreText.text = "Speed " + speed + player.position.z.ToString("0");
        SpeedText.text = "SPEED " + baseSpeed.ToString("0");
    }*/
}
