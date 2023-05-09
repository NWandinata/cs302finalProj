using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{ 
    private Rigidbody2D rb;
 
    private bool canJump;

    private float jumpHeight;

    PlayerMovement pm;
    [SerializeField] GameObject player;
    private Rigidbody2D playerBody;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovement>();
        playerBody = player.GetComponent<Rigidbody2D>();
        jumpHeight = pm.speed - 1; //jump height is equal to the max jump for player
    }

    private void Start()
    {
    }

    private void Update()
    {
        HandleJumping();
    }


    void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rb.velocity = new Vector2(0f, jumpHeight);
        }
    }

    // Enemy will jump when player jumps or when player is rotating faster than 1 rev/sec
    void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) || playerBody.angularVelocity > 6)
        {
            Jump();
        }

        if (rb.velocity.magnitude == 0) //only allow the enemy to jump again if their velocity returns to zero
            canJump = true;
    }

} // class