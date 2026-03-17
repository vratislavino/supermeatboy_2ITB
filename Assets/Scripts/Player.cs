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

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = move.x * speed;

        renderer.flipX = move.x < 0;

        animator.SetFloat("xspeed", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("yspeed", rb.linearVelocityY);
    }
}
