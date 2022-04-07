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
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        int point = PlanetsBase.point;
        ScoreText.text = "SCORE " + point;
    }
}
