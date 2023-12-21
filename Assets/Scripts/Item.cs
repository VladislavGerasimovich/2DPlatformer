using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Collider2D _collider;

    public void PlayMusic()
    {
        _audioSource.Play();
    }

    public void Enable()
    {
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }

    public void Disable()
    {
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
    }
}
