using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    public event UnityAction Died;

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    private void Awake()
    {
        Health = 5;
        MaxHealth = 5;
    }

    public void IncreaseHealth()
    {
        Health++;
    }

    public void TakeDamage()
    {
        Health--;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        Health = 5;
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
