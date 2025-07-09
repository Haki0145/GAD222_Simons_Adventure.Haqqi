using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isfacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 recordedVelocity;
    private bool canMove = true;

    public void StartMovement()
    {
        canMove = true;
        rb.linearVelocity = recordedVelocity;
    }

    public void StopMovement()
    {
        recordedVelocity = rb.linearVelocity;
        rb.linearVelocity = Vector2.zero;
        horizontal = 0f;
        canMove = false;
    }
   


    private void Update()
    {
        if (!canMove )
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); 
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f)
        {
            isfacingRight =!isfacingRight;
            Vector3 localscale = transform.localScale; 
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
