using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    private ScoreManager scoreM;

    public int darah = 1; //banyak kesempatan si objek bisa nabrak objek lain

    public float invulnPeriod = 0;

    float kebal = 0; //keadaan si objek ga kena pengaruh apa apa

    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        scoreM = GameObject.Find("Score").GetComponent<ScoreManager>();

        spriteRend = GetComponent<SpriteRenderer>();
        if(spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' tidak punya sprite renderer.");
            }
        }
    }

    //ngasi tau kalo udah nabrak ato belom
    void OnTriggerEnter2D()
    {
        //Debug.Log("Object Triggered");
        darah--;
        if (invulnPeriod > 0)
        {
            kebal = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    //aksi setelahnya
    void Update()
    {
        
        if(kebal > 0){
            kebal -= Time.deltaTime;
            if (kebal <= 0){
                gameObject.layer = correctLayer;
                if(spriteRend != null){
                    spriteRend.enabled = true;
                }
            }
            else{
                if (spriteRend != null){
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (darah <= 0)
        {
            Debug.Log(gameObject.tag);

            if (gameObject.tag == "Enemy")
            {
                scoreM.addScore();
            }
            Debug.Log(scoreM.score);

            Hancur();


        }
    }

    void Hancur()
    {
        Destroy(gameObject);
    }
}
