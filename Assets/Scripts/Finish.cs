using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private Transform _coins;
    [SerializeField] private AudioSource _audioSourceFail;
    [SerializeField] private AudioSource _audioSourceVictory;

    public event UnityAction ShowFinishWindow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(player.Score < _coins.childCount)
            {
                _audioSourceFail.Play();
                ShowFinishWindow?.Invoke();
            }
            if(player.Score == _coins.childCount)
            {
                _audioSourceVictory.Play();
                player.Die();
            }
        }
    }
}
