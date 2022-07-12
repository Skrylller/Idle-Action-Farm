using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathAnglesU;

[System.Serializable]
public class PlayerWalk : _PlayerState
{
    [SerializeField] private float _speed;
    private Vector3 _walkEulerAngles;
    private Vector3 _walkDirectional;

    public override void StateFUpdate()
    {
        _playerController.transform.Translate(_walkDirectional * _speed * Time.fixedDeltaTime, Space.World);
        _playerController.transform.eulerAngles = _walkEulerAngles;
    }

    public void SetDirectional(Vector2 point1, Vector2 point2)
    {
        float angle = MathfAngles.FindAngle(point1, point2);

        Vector2 directional = MathfAngles.FindDirectional(angle, _speed);

        _walkEulerAngles = new Vector3(0, -angle, 0);
        _walkDirectional = new Vector3(directional.x, 0, directional.y);
    }
    public void SetDirectional(Vector3 directional)
    {
        _walkDirectional = directional;
    }
}
