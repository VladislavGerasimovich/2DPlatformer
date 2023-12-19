using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Score { get; private set; }

    private void Start()
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

    public void IncreaseScore()
    {
        Score++;
        ScoreChanged.Invoke(Score);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        Score = 0;
        Health = 5;
    }


    public void Die()
    {
        GameOver?.Invoke();
    }
}
