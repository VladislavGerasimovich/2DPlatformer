using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _minHeight = -2.4f;

    private void Update()
    {
        if(_player.transform.position.y > _minHeight)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + -_minHeight, transform.position.z);
        }
    }
}
