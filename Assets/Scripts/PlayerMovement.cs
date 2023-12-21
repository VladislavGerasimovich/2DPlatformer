using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _horizontalMove;
    private float _speed;
    private float _jumpingPower;
    private bool _grounded;
    private AnimatorData _animatorData;
    private Vector2 _velocity;

    private void Awake()
    {
        _velocity = _rigidbody.velocity;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animatorData = new AnimatorData();
        _speed = 8f;
        _jumpingPower = 36f;
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat(_animatorData.Speed, _horizontalMove);
        _velocity = new Vector2(_horizontalMove * _speed, _velocity.y);
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);

        if (Input.GetButtonDown("Jump") && _grounded)
        {
            _velocity = new Vector2(_velocity.x, _jumpingPower);
        }

        if(Input.GetButtonDown("Jump") && _velocity.y > 0)
        {
            _velocity = new Vector2(_velocity.x, _velocity.y * 0.5f);
        }

        if (_velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (_velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}

public class AnimatorData
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));
    public readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
}
