using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public Action UpdateInventory;

    public PlayerStats playerStats { get; private set; }

    public int cultureCount { get; private set; }
    private int _inventoryCost;

    public void Init(PlayerStats plyerStats)
    {
        playerStats = plyerStats;
        UpdateInventory?.Invoke();
    }

    public bool FreeInventory()
    {
        return cultureCount >= playerStats.inventorySize ? false : true;
    }

    public void PlusCulture(CultureObject culture)
    {
        cultureCount++;
        _inventoryCost += culture.costCulture;
        UpdateInventory?.Invoke();
    }
}
