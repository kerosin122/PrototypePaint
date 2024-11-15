using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{


    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerMover playerMover;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        Vector2 moveInput = playerMover.GetMoveInput();

        
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }

        
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}