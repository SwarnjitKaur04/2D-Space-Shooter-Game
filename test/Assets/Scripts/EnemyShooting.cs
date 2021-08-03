using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletoffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletLayer;
    public float fireDelay = 0.50f;
    float cooldownTimer = 0f;
    Transform player;
    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    //Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            //Find the player's ship!
            GameObject go = GameObject.Find("player-ship");
            if (go != null)
            {
                player = go.transform;
            }
        }
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4)
        {
            //SHOOT!
            Debug.Log(" Enemy Pew!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletoffset;
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
