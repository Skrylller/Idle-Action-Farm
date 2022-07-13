using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureDetector : MonoBehaviour
{
    private PlayerController _player;

    private void Start()
    {
        _player = SingletoneComponentsManager.main.player;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Culture")
        {
            _player.SetState(_player.mowState);
        }
    }
}
