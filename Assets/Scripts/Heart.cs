using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    public int AmountOfHealth { get; private set; }

    private void Awake()
    {
        AmountOfHealth = 1;
    }
}
