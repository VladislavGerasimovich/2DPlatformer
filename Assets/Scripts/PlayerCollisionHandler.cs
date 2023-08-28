using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Point point))
        {
            _player.IncreaseScore();
        }

        if (collision.TryGetComponent(out WayPointMovement wayPointMovement))
        {
            _player.Die();
        }

        if(collision.TryGetComponent(out Spike spike))
        {
            _player.Die();
        }
    }
}
