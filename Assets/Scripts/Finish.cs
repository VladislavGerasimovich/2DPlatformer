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
    [SerializeField] private Score _score;

    public event UnityAction PlayerCameUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(_score.Count < _coins.childCount)
            {
                _audioSourceFail.Play();
                PlayerCameUp?.Invoke();
            }

            if(_score.Count == _coins.childCount)
            {
                _audioSourceVictory.Play();
                player.Die();
            }
        }
    }
}
