using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    public Joystick joystick { get { return _joystick; }}
}