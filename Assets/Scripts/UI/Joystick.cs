using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathAnglesU;

public class Joystick : MonoBehaviour
{
    [SerializeField] private Transform StickBack;
    [SerializeField] private Transform StickHand;

    [SerializeField] private float _maxRadius;

    private InputSystem _input;

    private void Start()
    {
        DeactiveJoystick();
    }

    private void OnEnable()
    {
        _input = SingletoneComponentsManager.main.input;
        _input.InputGetTouch += SetJoystickPosition;
        _input.InputGetTouchUp += DeactiveJoystick;
    }

    private void OnDisable()
    {
        _input.InputGetTouch -= SetJoystickPosition;
        _input.InputGetTouchUp -= DeactiveJoystick;
    }

    public void SetJoystickPosition()
    {
        StickBack.gameObject.SetActive(true);
        StickHand.gameObject.SetActive(true);

        StickBack.position = _input.startTouchPosition;

        Vector2 handPos = _input.currentTouchPosition;

        if (Vector2.Distance(_input.startTouchPosition, _input.currentTouchPosition) > _maxRadius)
        {
            handPos = (Vector2)_input.startTouchPosition + MathfAngles.FindDirectional(MathfAngles.FindAngle(_input.currentTouchPosition, _input.startTouchPosition), _maxRadius);
        }

        StickHand.position = handPos;
    }

    public void DeactiveJoystick()
    {
        StickBack.gameObject.SetActive(false);
        StickHand.gameObject.SetActive(false);
    }
}
