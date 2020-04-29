using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeCtrl : MonoBehaviour {

    public TextMeshProUGUI YourScore;

    private void Start()
    {
        YourScore.text = PlayerPrefs.GetFloat("Current Score").ToString();

        Debug.Log(PlayerPrefs.GetFloat("Current Score") + "--" + PlayerPrefs.GetFloat("High Score"));

        if (PlayerPrefs.GetFloat("Current Score") >= PlayerPrefs.GetFloat("High Score"))
        {
            YourScore.text = "CONGRATULATION\nNEW HIGH SCORE!\n" + PlayerPrefs.GetFloat("Current Score");
        }
        else
        {
            YourScore.text = "YOUR SCORE!\n" + PlayerPrefs.GetFloat("Current Score");
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

}
