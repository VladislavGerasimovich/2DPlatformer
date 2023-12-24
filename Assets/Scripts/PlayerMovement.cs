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

    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _horizontalMove;
    private float _speed;
    private float _jumpingPower;
    private bool _grounded;
    private AnimatorData _animatorData;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorData = new AnimatorData();
        _animator = GetComponent<Animator>();
        _speed = 8f;
        _jumpingPower = 36f;
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(Horizontal);
        _animator.SetFloat(_animatorData.Speed, _horizontalMove);
        _rigidbody.velocity = new Vector2(_horizontalMove * _speed, _rigidbody.velocity.y);
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        _animator.SetBool(_animatorData.IsJumping, false);

        if (Input.GetButtonDown(Jump) && _grounded)
        {
            _animator.SetBool(_animatorData.IsJumping, true);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpingPower);
        }

        if(Input.GetButtonDown(Jump) && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }

        if (_rigidbody.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (_rigidbody.velocity.x > 0)
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
