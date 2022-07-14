using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureDetector : MonoBehaviour
{
    private PlayerController _player;

    private void Start()
    {
        _player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(_player != null && other.tag == "Culture")
        {
            _player.SetState(_player.mowState);
        }
    }
}
