using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signalling : MonoBehaviour
{
    [SerializeField] private float number;

    public event UnityAction<bool> OnSignalling;

    private void Update()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, number, mask);

        if (hit)
        {
            OnSignalling?.Invoke(true);
        }
        else
        {
            OnSignalling?.Invoke(false);
        }
    }
}
