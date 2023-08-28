using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private TMP_Text _maxValue;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _coins;

    private void Start()
    {
        _maxValue.text =  $"/ {_coins.childCount.ToString()}";
    }

    public void Reset()
    {
        _currentValue.text = "0";
    }

    private void OnEnable()
    {
        _player.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(int score)
    {
        _currentValue.text = score.ToString();
    }
}
