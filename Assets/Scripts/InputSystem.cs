using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    public event Action InputGetTouch;
    public event Action InputGetTouchUp;

    public Vector3 startTouchPosition { get; private set; }
    public Vector3 currentTouchPosition { get; private set; }

private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
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
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            currentTouchPosition = Input.mousePosition;
            InputGetTouch?.Invoke();

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            InputGetTouchUp?.Invoke();
        }
    }
}
