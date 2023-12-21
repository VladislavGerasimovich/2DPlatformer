using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _number;

    private LayerMask _mask;

    public event UnityAction<bool> PlayerSpotted;

    private void Awake()
    {
        _mask = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _number, _mask);

        if (hit)
        {
            PlayerSpotted?.Invoke(true);
        }
        else
        {
            PlayerSpotted?.Invoke(false);
        }
    }
}
