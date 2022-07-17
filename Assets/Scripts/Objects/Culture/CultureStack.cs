using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CultureStack : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateDirectional;
    [SerializeField] private float _speedMagnetic;

    private PlayerController _playerController;
    public CultureObject cultureObject { get; private set; }

    private void OnEnable()
    {
        _playerController = SingletoneComponentsManager.main.player;
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
        Vector3 animRotation = _playerController.state == _playerController.walkState ? _rotateDirectional * Time.deltaTime : new Vector3() * Time.deltaTime;
        animation.Append(transform.DORotate(transform.eulerAngles + animRotation, 0, RotateMode.Fast));
        animation.OnComplete(RotateAnimation);
    }

}
