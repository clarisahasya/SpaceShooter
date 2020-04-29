using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score;

    public int HighScore;

    public TextMeshProUGUI scoreText;

    

    public void addScore ()
    {
        score++;

        PlayerPrefs.SetFloat("Current Score", score);

        scoreText.text = "SCORE "+score.ToString();

        if (score > PlayerPrefs.GetFloat("High Score"))
        {
            PlayerPrefs.SetFloat("High Score", score);
        }

    }
    

    void Start()
    {
        Debug.Log(scoreText.text);
    }
}
