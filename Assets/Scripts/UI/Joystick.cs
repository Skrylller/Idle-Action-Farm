using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathAnglesU;

public class Joystick : MonoBehaviour
{
    [SerializeField] private Transform StickBack;
    [SerializeField] private Transform StickHand;

    [SerializeField] private float _maxRadius;

    private void Start()
    {
        DeactiveJoystick();
    }

    public void SetJoystickPosition(Vector2 startPos, Vector2 handPos)
    {
        StickBack.gameObject.SetActive(true);
        StickHand.gameObject.SetActive(true);

        StickBack.position = startPos;

        if(Vector2.Distance(startPos, handPos) > _maxRadius)
        {
            handPos = startPos + MathfAngles.FindDirectional(MathfAngles.FindAngle(handPos, startPos), _maxRadius);
        }

        StickHand.position = handPos;
    }

    public void DeactiveJoystick()
    {
        StickBack.gameObject.SetActive(false);
        StickHand.gameObject.SetActive(false);
    }
}
