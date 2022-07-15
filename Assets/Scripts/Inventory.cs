using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public Action UpdateInventory;
    public Action<int, int, Transform> SaleInventoryAction;

    public int inventorySize { get; private set; }

    public int cultureCount { get; private set; }
    public int money { get; private set; }
    private int _inventoryCost;

    public void Init(PlayerStats plyerStats)
    {
        inventorySize = plyerStats.inventorySize;
        UpdateInventory?.Invoke();
    }

    public bool FreeInventory()
    {
        return cultureCount >= inventorySize ? false : true;
    }

    public void PlusCulture(CultureObject culture)
    {
        cultureCount++;
        _inventoryCost += culture.costCulture;
        UpdateInventory?.Invoke();
    }

    public void PlusMoney(int value)
    {
        money += value;
        UpdateInventory?.Invoke();
    }

    public void SaleInventory(Transform salePoint)
    {
        if (_inventoryCost <= 0)
            return;

        SaleInventoryAction?.Invoke(cultureCount, _inventoryCost, salePoint);
        _inventoryCost = 0;
    }

    public void MinusCulture(int cultureValue)
    {
        cultureCount -= cultureValue;
        cultureCount = cultureCount < 0 ? 0 : cultureCount;

        UpdateInventory?.Invoke();
    }

}
