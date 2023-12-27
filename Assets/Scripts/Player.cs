using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : Character
{
    [SerializeField] private Vector3 _startPosition;

    public event UnityAction Died;

    public override void Reset()
    {
        base.Reset();
        transform.position = _startPosition;
    }

    public override void Die()
    {
        Died?.Invoke();
    }
}
