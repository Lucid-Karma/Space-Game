using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText
    {
        get
        {
            if(scoreText == null)
            scoreText = GetComponent<TextMeshProUGUI>();

            return scoreText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(UpdateScoreText);
        //EventManager.OnGameStart.AddListener(RecreateScore);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdateScoreText);
        //EventManager.OnGameStart.RemoveListener(RecreateScore); 
    }

    public int point = 0;
    private void UpdateScoreText()
    {
        point = PlanetsBase.point;
        ScoreText.text = "SCORE " + point;
    }

    /*public void RecreateScore()
    {
        point = 0;
    }*/
}
