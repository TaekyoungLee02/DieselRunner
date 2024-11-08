using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float G_FORCE = 100f;

    [SerializeField]
    [Range(0, 10f)]
    private float speed;
    [SerializeField]
    [Range(0, 50f)]
    private float jumpPower;
    [SerializeField]
    private float maxJumpPower;
    [SerializeField]
    private float maxFallSpeed;
    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private float boxDistance;

    private float xInput;
    private float yInput;
    private float yVelocity;

    private bool jumpInput;
    private bool jumpButtonPushing;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;

    private Rigidbody2D rb2d;
    private Collider2D col2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }


    // Key Input and Physical Computing should be Separated (key input -> update / physical -> fixedUpdate)
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetKey(KeyCode.Space);

        GroundedCheck();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // If Character is Grounded
        if (isGrounded)
        {
            yVelocity = 0;
            isFalling = false;
            isJumping = false;

            // Checks If Player Keeps Pushing Jump Button After Jump Ends
            if (!jumpInput) jumpButtonPushing = false;

            if (jumpInput && !jumpButtonPushing)
            {
                isJumping = true;
                jumpButtonPushing = true;
                yVelocity = jumpPower;
            }
        }
        else if (!isJumping)
        {
            isFalling = true;
        }

        // If Character is Jumping
        if (isJumping)
        {
            // if Player Keeps pushing down Jump key, strengthen jump power (if jump power is lower than max Jump power)
            if (jumpInput && yVelocity < maxJumpPower)
            {
                yVelocity += Time.deltaTime * jumpPower;
            }

            // if player stops pushing down Jump key, character falls
            else
            {
                isJumping = false;
            }
        }

        // If Character is falling
        if (isFalling)
        {
            yVelocity -= G_FORCE * Time.deltaTime;
        }

        // Set Max Fall Speed
        if (yVelocity < -maxFallSpeed) yVelocity = -maxFallSpeed;

        // yVelocity Debug
        //Debug.Log(yVelocity);

        rb2d.velocity = new Vector2(xInput * speed * Time.deltaTime * 100, yVelocity);
    }

    private void GroundedCheck()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(col2d.bounds.center, boxSize, 0f, -transform.up, boxDistance, LayerMask.GetMask("Ground"));

        if (raycast.collider != null)
        {
            if (raycast.collider.CompareTag("Ground") || raycast.collider.CompareTag("Trap"))
            {
                isGrounded = true;
                transform.SetParent(raycast.collider.transform);
            }
        }
        else isGrounded = false;
    }
}
