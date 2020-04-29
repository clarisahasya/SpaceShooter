using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawner : MonoBehaviour {

    public TextMeshProUGUI livesLeftText;

    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 2;

    float respawnTimer;

	// Use this for initialization
	void Start () {
        SpawnPlayer();
	}

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        
    }
	
	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
	}

    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            livesLeftText.text = "LIVES LEFT " + numLives;
            //GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
        }
        else
        {
            SceneManager.LoadScene(2);
            //GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over, DUDE!");
        }
    }
}
