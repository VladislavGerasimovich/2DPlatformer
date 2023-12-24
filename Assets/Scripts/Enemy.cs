using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int Damage { get; private set; }

    private void Awake()
    {
        Damage = 1;
    }
}

