using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 10;

    private float horizontal;

    Animator animator;
    Rigidbody2D rigidBody2DMovement;
    SpriteRenderer spriteRendered;

    private bool _inAir;
    private bool _jump;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2DMovement = GetComponent<Rigidbody2D>();
        spriteRendered = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        _jump = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !_inAir;

        horizontal = Input.GetAxis("Horizontal");

        spriteRendered.flipX = horizontal < 0 ? true : (horizontal == 0 ? spriteRendered.flipX : false);

        if (horizontal != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
    private void FixedUpdate()
    {
        rigidBody2DMovement.velocity = new Vector2(_speed * horizontal, rigidBody2DMovement.velocity.y);

        if (_jump)
        {
            rigidBody2DMovement.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _inAir = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _inAir = true;
        }
    }
}
