using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 10;

    private Rigidbody2D _rigidBody2DMovement;
    private Animator _animator;
    private SpriteRenderer _spriterendered;

    private float horizontal;
    private bool _inAir;
    private bool _jump;
    private bool _downMove;
    private bool _isFalling;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2DMovement = GetComponent<Rigidbody2D>();
        _spriterendered = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _jump = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !_inAir;
        horizontal = Input.GetAxis("Horizontal");
        _spriterendered.flipX = horizontal < 0 ? true : (horizontal == 0 ? _spriterendered.flipX : false);

        if (horizontal != 0)
        {
            _animator.SetTrigger("Run");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }

        _downMove = _rigidBody2DMovement.velocity.y < 0;
        if (_inAir && _downMove && !_isFalling)
        {
            _isFalling = true;
            _animator.SetTrigger("Fall");
        }
        if (_jump)
        {
            _rigidBody2DMovement.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
    }
    private void FixedUpdate()
    {
        _rigidBody2DMovement.velocity = new Vector2(_speed * horizontal, _rigidBody2DMovement.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _inAir = false;
            _isFalling = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _inAir = true;
        }
    }
}
