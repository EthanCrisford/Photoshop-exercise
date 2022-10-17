using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    LayerMask groundLayerMask;
    float playerx, playery;
    float enemyx, enemyy;
    public GameObject player;
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 25;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;

    public bool _moveRight = true;

    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0; 
    }

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

        if(_moveRight)
    
            enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
            if (!_isFacingRight)
                Flip();

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime);
            if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;

    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }


}
