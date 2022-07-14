using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private TMP_Text _inventoryText;
    [SerializeField] private TMP_Text _moneyText;

    private void OnEnable()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
        _inventory.UpdateInventory += InventoryTextUpdate;
    }

    private void OnDisable()
    {
        _inventory.UpdateInventory -= InventoryTextUpdate;
    }

    public void InventoryTextUpdate()
    {
        _inventoryText.text = $"{_inventory.cultureCount}/{_inventory.playerStats.inventorySize}";

    }
}