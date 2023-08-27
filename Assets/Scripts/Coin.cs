using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _audioSource.Play();
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
        }
    }
}
