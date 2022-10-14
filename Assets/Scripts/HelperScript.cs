using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    bool IsGrounded = false;
    
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("ground");
    }

    public void DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        //cast a ray downwards of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
            hitColor = Color.green;
        }
        else
        {
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
            hitColor = Color.red;
            IsGrounded = true; 
        }
    }

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}