using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2DMovement;
    SpriteRenderer spiriteRendered;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2DMovement = GetComponent<Rigidbody2D>();
        spiriteRendered = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody2DMovement.velocity = new Vector2(10, rigidBody2DMovement.velocity.y);
            animator.Play("Player_run");
            spiriteRendered.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody2DMovement.velocity = new Vector2(-10, rigidBody2DMovement.velocity.y);
            animator.Play("Player_run");
            spiriteRendered.flipX = true;
        }
        else
        {
            animator.Play("Player_idle");
            rigidBody2DMovement.velocity = new Vector2(0, rigidBody2DMovement.velocity.y);
        }

        if (Input.GetKey("space") || Input.GetKey("up"))
        {
            rigidBody2DMovement.velocity = new Vector2(rigidBody2DMovement.velocity.x, 3);
            animator.Play("Player_jump");
        }

    }
}
