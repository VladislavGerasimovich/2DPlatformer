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

    public int Count {  get; private set; }

    private void Awake()
    {
        _maxValue.text =  $"/ {_coins.childCount.ToString()}";
    }

    public void Reset()
    {
        Count = 0;
        _currentValue.text = "0";
    }

    public void IncreaseCount()
    {
        Count++;
        ScoreChanged();
    }

    private void ScoreChanged()
    {
        _currentValue.text = Count.ToString();
    }
}
