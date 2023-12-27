using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Ability : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;

    private int _duration;
    private int _interval;
    private int _amountOfHealth;
    private WaitForSeconds _delay;
    private bool _isCollision;
    private Enemy _currentEnemy;

    private void Awake()
    {
        _amountOfHealth = 1;
        _interval = 1;
        _duration = 6;
        _delay = new WaitForSeconds(1);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            _isCollision = true;
            _currentEnemy = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isCollision = false;
    }

    private void OnButtonClick()
    {
        if (_isCollision)
        {
            _button.interactable = false;
            StartCoroutine(UseAbility());
        }
    }

    private IEnumerator UseAbility()
    {
        float time = 0;

        while(time < _duration && _player.CurrentHealth < _player.MaxHealth &&  _currentEnemy.CurrentHealth > 0 && _isCollision)
        {
            yield return _delay;

            _currentEnemy.TakeDamage(_amountOfHealth);
            _player.IncreaseHealth(_amountOfHealth);
            time += _interval;
        }

        _button.interactable = true;
    }
}
