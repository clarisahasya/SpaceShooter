using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuCtrl : MonoBehaviour {

    public TextMeshProUGUI HighScoreText;

    private void Start()
    {
        float HighScore = 0;

        HighScore = PlayerPrefs.GetFloat("High Score");

        //print(myVariable);

        Debug.Log("Test: "+HighScore);

        //PlayerPrefs.SetFloat("High Score", 0f);
        HighScoreText.text = "HIGH SCORE " + HighScore;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);      
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
}
