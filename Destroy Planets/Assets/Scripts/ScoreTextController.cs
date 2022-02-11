using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    private Text scoreText;
    public Text ScoreText
    {
        get
        {
            if(scoreText == null)
            scoreText = GetComponent<Text>();

            return scoreText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(UpdateScoreText);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        int point = PlanetsBase.point;
        ScoreText.text = "Score" + point;
    }
}
