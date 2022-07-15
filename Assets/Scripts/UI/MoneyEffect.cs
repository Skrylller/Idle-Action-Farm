using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyEffect : MonoBehaviour
{
    [SerializeField] private float _duration;
    private int _cost;

    private Transform _target;
    private Inventory _inventory;

    private void OnEnable()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
        _target = SingletoneComponentsManager.main.UIController.moneyTarget;
    }

    public void Init(int cost)
    {
        _cost = cost;
        var animation = DOTween.Sequence();
        animation.Append(transform.DOMove(_target.position, _duration));
        animation.OnComplete(Complete);
    }

    private void Complete()
    {
        _inventory.PlusMoney(_cost);
        gameObject.SetActive(false);
    }
}
