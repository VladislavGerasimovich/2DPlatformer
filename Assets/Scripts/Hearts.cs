using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField] private Transform _hearts;
    [SerializeField] private Transform _randomPlaces;
    [SerializeField] private Heart _heart;

    private int _heartsCount;

    private void Awake()
    {
        _heartsCount = 3;
    }

    private void Start()
    {
        for (int i = 0; i < _heartsCount; i++)
        {
            int index = Random.Range(0, _randomPlaces.childCount);
            Instantiate(_heart, _randomPlaces.GetChild(index).position, Quaternion.identity, transform);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < _hearts.childCount; i++)
        {
            _hearts.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            _hearts.GetChild(i).GetComponent<Collider2D>().enabled = true;
        }
    }
}
