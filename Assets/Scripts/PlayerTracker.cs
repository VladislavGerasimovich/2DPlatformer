using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if(_player.transform.position.y > -2.4f)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 2.5f, transform.position.z);
        }
    }
}
