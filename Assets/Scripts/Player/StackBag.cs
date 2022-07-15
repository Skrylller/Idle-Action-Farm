using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackBag : MonoBehaviour
{
    [System.Serializable]
    private  class StackInBag
    {
        public GameObject _objectInBag;
        [HideInInspector] public Vector3 startPosition;
        [HideInInspector] public int cost;

        public void SetStartPosition()
        {
            SingletoneComponentsManager.main.objectPulls.ActivateMoney(_objectInBag.transform.position, cost);
            _objectInBag.transform.localPosition = startPosition;
            _objectInBag.SetActive(false);
        }
    }

    [SerializeField] private List<StackInBag> _stacksInBag = new List<StackInBag>();

    [SerializeField] private float _defferedAnimationSalesStack;
    [SerializeField] private float _delaySalesStack;

    private Inventory _inventory;

    private void OnEnable()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
        _inventory.UpdateInventory += SetInventory;
        _inventory.SaleInventoryAction += SaleStacks;
        DisableInventory();
        SetInventory();
    }

    private void OnDisable()
    {
        _inventory.UpdateInventory -= SetInventory;
        _inventory.SaleInventoryAction -= SaleStacks;
    }

    private void DisableInventory()
    {
        for (int i = 0; i < _stacksInBag.Count; i++)
        {
            _stacksInBag[i]._objectInBag.SetActive(false);
        }
    }

    public void SetInventory()
    {
        int occupancy = ReturnOccupancy();
        occupancy = occupancy <= 0 && _inventory.cultureCount > 0 ? 1 : occupancy;

        for(int i = 0; i < occupancy; i++)
        {
            _stacksInBag[i]._objectInBag.SetActive(true);
        }
    }

    private int ReturnOccupancy()
    {
        int occupancy = (int)((float)_inventory.cultureCount / _inventory.inventorySize * _stacksInBag.Count);
        return occupancy == 0 && _inventory.cultureCount > 0 ? 1 : occupancy;
    }

    private void SaleStacks(int cost, int cultureCount, Transform salePoint)
    {
        StartCoroutine(SaleStacksCourotine(cost, cultureCount, salePoint));
    }

    private IEnumerator SaleStacksCourotine(int costAllStacks, int cultureCount, Transform salePoint)
    {
        int occupancy = ReturnOccupancy();
        int oneStackCost = costAllStacks / occupancy;
        int oneStackCultureCount = cultureCount / occupancy;

        for (int i = occupancy - 1; i >= 0; i--)
        {
            _stacksInBag[i].startPosition = _stacksInBag[i]._objectInBag.transform.localPosition;

            if (i != 0)
            {
                _inventory.MinusCulture(oneStackCultureCount);
                _stacksInBag[i].cost = oneStackCost;
            }
            else
            {
                _inventory.MinusCulture(cultureCount);
                _stacksInBag[i].cost = costAllStacks;
            }

            cultureCount -= oneStackCultureCount;
            costAllStacks -= _stacksInBag[i].cost;

            var animation = DOTween.Sequence();
            animation.Append(_stacksInBag[i]._objectInBag.transform.DOMove(salePoint.position, _defferedAnimationSalesStack));
            animation.OnComplete(_stacksInBag[i].SetStartPosition);

            yield return new WaitForSeconds(_delaySalesStack);
        }
    }
}
