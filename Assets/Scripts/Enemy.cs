using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    LayerMask groundLayerMask;
    float playerx, playery;
    float enemyx, enemyy;
    public GameObject player;

    public bool DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        //cast a ray downwards of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        if (hit.collider == null)
        {
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, Color.black);

            return false;
        }
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, Color.red);

        return true;
    }

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
