using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int Damage { get; private set; }

    public override void OnAwake()
    {
        base.OnAwake();
        Damage = 1;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}

