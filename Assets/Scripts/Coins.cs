using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Transform _coins;

    public void Reset()
    {
        foreach (Transform coin in _coins)
        {
            coin.GetComponent<Coin>().Enable();
        }
    }
}

