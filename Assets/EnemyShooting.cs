using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.50f;
    float cooldownTimer = 0;

    public Transform player;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            // mencari mainplane
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        if ( cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 5)
        {
            //nembak
            //Debug.Log("DOOOOOR!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
    }
}
