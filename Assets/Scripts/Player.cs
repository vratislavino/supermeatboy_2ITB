using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    InputAction moveAction;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundLayerMask;

    [SerializeField]
    private float jumpForce = 10;

    private bool isGrounded;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = IsGrounded();

        var move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = move.x * speed;

        if (isGrounded && move.y > 0)
            Jump();

        renderer.flipX = move.x < 0;

        animator.SetFloat("xspeed", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("yspeed", rb.linearVelocityY);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayerMask);
    }

    private void Jump()
    {
        rb.linearVelocityY = jumpForce;
    }
}
