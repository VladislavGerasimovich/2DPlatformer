using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Transform _coins;

    public void Reset()
    {
        for (int i = 0; i < _coins.childCount; i++)
        {
            _coins.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            _coins.GetChild(i).GetComponent<Collider2D>().enabled = true;
        }
    }
}

