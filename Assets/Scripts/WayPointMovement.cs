using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SpriteRenderer))]
public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Player _player;
    [SerializeField] private Signalling _signalling;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint;
    private float _speed;
    private bool _isChase;

    private void OnEnable()
    {
        _signalling.OnSignalling += StartChase;
    }

    private void OnDisable()
    {
        _signalling.OnSignalling -= StartChase;
    }

    private void Awake()
    {
        _speed = 1;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];
        
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Start()
    {
        StartCoroutine(Chase());
        StartCoroutine(MoveBetweenPoints());
    }

    private void StartChase(bool isChase)
    {
        _isChase = isChase;
    }

    private IEnumerator Chase()
    {
        bool isWork = true;

        while (isWork)
        {
            Move(_player.transform);

            if (_isChase == false)
            {
                isWork = false;
                StartCoroutine(MoveBetweenPoints());
            }

            yield return null;
        }
    }

    private IEnumerator MoveBetweenPoints()
    {
        bool isWork = true;

        while (isWork)
        {
            Transform target = _points[_currentPoint];
            Move(target);

            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }

            if(_isChase)
            {
                isWork = false;
                StartCoroutine(Chase());
            }

            yield return null;
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        Vector3 direction = (transform.position - target.position).normalized;

        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
