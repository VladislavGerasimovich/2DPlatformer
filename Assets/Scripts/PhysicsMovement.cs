using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private LayerMask _layerMask;

    private const float _minMoveDistance = 0.001f;
    private const float _shellRadius = 0.01f;

    private AnimatorData _animatorData = new AnimatorData();
    private float _speed;
    private Vector2 _targetVelocity;
    private bool _grounded;
    private Vector2 _groundNormal;
    private Rigidbody2D _rigidbody;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _hitBuffer;
    private List<RaycastHit2D> _hitBufferList;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _hitBuffer = new RaycastHit2D[16];
        _hitBufferList = new List<RaycastHit2D>(16);
        _speed = 3f;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal") * _speed, 0);
        _animator.SetFloat(_animatorData.Speed, Mathf.Abs(Input.GetAxis("Horizontal")));

        if(_targetVelocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if(_targetVelocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && _grounded)
        {
            _velocity.y = 8;
            _animator.SetBool(_animatorData.IsJumping, true);
        }

        if (!_grounded)
        {
            _animator.SetBool(_animatorData.IsJumping, false);
        }
    }

    private void FixedUpdate()
    {
        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = _targetVelocity.x;

        _grounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Move(move, false);

        move = Vector2.up * deltaPosition.y;

        Move(move, true);
    }

    private void Move(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > _minMoveDistance)
        {
            int count = _rigidbody.Cast(move, _contactFilter, _hitBuffer, distance + _shellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;

                if (currentNormal.y > _minGroundNormalY)
                {
                    _grounded = true;

                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);

                if (projection < 0)
                {
                    _velocity = _velocity - projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - _shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rigidbody.position = _rigidbody.position + move.normalized * distance;
    }
}

public class AnimatorData
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));
    public readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
}
