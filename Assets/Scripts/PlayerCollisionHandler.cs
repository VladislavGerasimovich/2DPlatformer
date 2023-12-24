using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Heart heart))
        {
            if(_player.CurrentHealth < _player.MaxHealth)
            {
                heart.PlayMusic();
                heart.Disable();
                _player.IncreaseHealth(heart.AmountOfHealth);
            }
        }

        if(collision.TryGetComponent(out Coin coin))
        {
            coin.PlayMusic();
            coin.Disable();
            _score.IncreaseCount();
        }

        if (collision.TryGetComponent(out Enemy enemy))
        {
            _player.TakeDamage(enemy.Damage);
        }

        if(collision.TryGetComponent(out Spike spike))
        {
            _player.Die();
        }
    }
}
