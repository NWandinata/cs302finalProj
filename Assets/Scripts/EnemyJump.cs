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


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovement>();
        jumpHeight = pm.speed - 1;
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

    void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (rb.velocity.magnitude == 0)
            canJump = true;
    }

} // class