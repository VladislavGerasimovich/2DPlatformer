using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;
    private Vector3 _startPosition = new Vector3(-9.18f, -2.35f, 0);

    public int Score { get; private set; }

    public void IncreaseScore()
    {
        Score++;
        ScoreChanged.Invoke(Score);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        Score = 0;
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
