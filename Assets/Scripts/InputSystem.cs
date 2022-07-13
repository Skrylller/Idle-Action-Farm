using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private Camera _camera;

    private Vector3 startTouchPosition;

    private PlayerController _player;
    private Joystick _joystick;

    private void Start()
    {
        _camera = Camera.main;
        _player = SingletoneComponentsManager.main.player;
        _joystick = SingletoneComponentsManager.main.UIController.joystick;
    }

    private void Update()
    {
        CheckInputTouchPosition();
    }

    private void CheckInputTouchPosition()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startTouchPosition = Input.mousePosition;
            _player.SetState(_player.walkState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            _player.walkState.SetDirectional(Input.mousePosition, startTouchPosition);
            _joystick.SetJoystickPosition(startTouchPosition, Input.mousePosition);
            _player.SetState(_player.walkState);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _player.walkState.SetDirectional(new Vector3(0,0,0));
            _player.SetState(_player.idleState);
            _joystick.DeactiveJoystick();
        }
    }
}
