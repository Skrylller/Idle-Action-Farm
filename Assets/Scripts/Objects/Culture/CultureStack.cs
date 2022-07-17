using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CultureStack : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateDirectional;
    [SerializeField] private float _speedMagnetic;
    public CultureObject cultureObject { get; private set; }

    private void OnEnable()
    {
        RotateAnimation();
    }

    public void Init(CultureObject culture)
    {
        cultureObject = culture;
    }

    public void TakeStack()
    {
        gameObject.SetActive(false);
    }

    public void MagneticToTarget(Vector3 target)
    {
        transform.DOMove(target, _speedMagnetic, false);
    }

    private void RotateAnimation()
    {
        var animation = DOTween.Sequence();
        animation.Append(transform.DORotate(transform.eulerAngles + _rotateDirectional * Time.deltaTime, 0, RotateMode.Fast));
        animation.OnComplete(RotateAnimation);
    }

}
