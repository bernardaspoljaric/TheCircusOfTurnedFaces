using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementPhysics
{
    [Header("Movement:")]
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 20;

    [Header("Noemi characteristics:")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        
    }
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;

            if (move.x > 0.1f && velocity.y == jumpTakeOffSpeed)
            {
               
            }
            if (move.x < -0.1 && velocity.y == jumpTakeOffSpeed)
            {
                
            }
            if (move.x == 0 && velocity.y == jumpTakeOffSpeed)
            {
                
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move * maxSpeed;

        if (move.x > 0.1f)
        {
            animator.SetBool("walkRight", true);
        }
        if (move.x < -0.1)
        {
            animator.SetBool("walkLeft", true);
        }
        if (move.x == 0)
        {
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkRight", false);
        }
    }
}
