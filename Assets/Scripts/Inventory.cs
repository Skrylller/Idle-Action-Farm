using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private BackBag _backBag;
    private PlayerStats _playerStats;
    private UIController _UIController;
    private int _cultureCount;
    private int _inventoryCost;

    public void Init(PlayerStats plyerStats)
    {
        _playerStats = plyerStats;
        _UIController = SingletoneComponentsManager.main.UIController;
        UpdateVisual();
    }

    public string InventoryText()
    {
        return $"{_cultureCount}/{_playerStats.inventorySize}";
    }

    public bool FreeInventory()
    {
        return _cultureCount >= _playerStats.inventorySize ? false : true;
    }

    public void PlusCulture(CultureObject culture)
    {
        _cultureCount++;
        _inventoryCost += culture.costCulture;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _UIController.InventoryTextUpdate(InventoryText());
        _backBag.SetInventory(_cultureCount, _playerStats.inventorySize);
    }
}
