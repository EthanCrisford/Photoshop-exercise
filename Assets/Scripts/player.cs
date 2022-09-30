using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D player1;
    public int speed;
    bool touchingPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        print(Input.GetKey("w"));

        if (Input.GetKey("w") && (touchingPlatform==true) )
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            player1.velocity = new Vector2(0, 7);
        }


        if (Input.GetKey("s"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            player1.velocity = new Vector2(0, -4);
        }



        if (Input.GetKey("a"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            player1.velocity = new Vector2(-5, 0);
        }


        if (Input.GetKey("d"))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            player1.velocity = new Vector2(5, 0);
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = false;
        }
    }
} 

