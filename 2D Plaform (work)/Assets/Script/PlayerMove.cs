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
    private bool _downMove; 
    private bool _isFalling;
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

        _downMove = rigidBody2DMovement.velocity.y < 0;
        if (_inAir && _downMove && !_isFalling)
        {
            _isFalling = true;
            animator.SetTrigger("Fall");
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
            _isFalling = false;
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
