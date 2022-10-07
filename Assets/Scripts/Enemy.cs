using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    float playerx, playery;
    float enemyx, enemyy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;

        enemyx = transform.position.x;
        if (playerx < enemyx)
            print("player is on the left");
        else print("player is on the right");
    }
}
