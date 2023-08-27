using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint;
    private float _speed = 2f;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        Vector3 direction = (transform.position - target.position).normalized;

        if(direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        if(direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

    }
}
