using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VibrationObject : MonoBehaviour
{
    private const float range = 5;
    private const float speed = 0.05f;
    private Vector2 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    public void Vibration()
    {
        var animation = DOTween.Sequence();
        for (int i = 0; i <= 10; i++)
        {
            animation.Append(transform.DOMove(startPos + new Vector2(Random.Range(-range, range), Random.Range(-range, range)), speed));
        }
        animation.Append(transform.DOMove(startPos, speed));
    }
}
