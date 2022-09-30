using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    bool touchingPlatform = false;
    private Animator anim;
    bool isWalking;
    bool walk;
    bool idle;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("idle", false);

        if (isJumping == false) && (walk = false);
        {
            anim.SetBool("idle", true);
        }

        // check for player landing
        if (isJumping && (touchingPlatform == true) && (rb.velocity.y < 0))
        {
            isJumping = false;
            anim.SetBool("idle", true);
        }



        if (Input.GetKey("space") && (touchingPlatform==true) )
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 7);
           
            anim.SetBool("jump", true);
            isJumping=true;
        }


        if (Input.GetKey("s"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            //player1.velocity = new Vector2(0, -4);
            //anim.SetBool("walk", true);
            //anim.SetBool("idle", false);
        }



        if (Input.GetKey("a"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(-5, 0);
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }


        if (Input.GetKey("d"))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(5, 0);
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }

        if( isJumping == true )
        {
            anim.SetBool("jump", true);
        }

        print("isjumping=" + isJumping);

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

