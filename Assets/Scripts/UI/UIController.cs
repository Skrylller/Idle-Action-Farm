using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private TMP_Text _inventoryText;
    [SerializeField] private TMP_Text _moneyText;

    [SerializeField] private Transform _moneyTarget;
    public Transform moneyTarget { get { return _moneyTarget; } }

    private void OnEnable()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
        _inventory.UpdateInventory += TextUpdate;
    }

    private void OnDisable()
    {
        _inventory.UpdateInventory -= TextUpdate;
    }

    public void TextUpdate()
    {
        _inventoryText.text = $"{_inventory.cultureCount}/{_inventory.inventorySize}";
        _moneyText.text = $"{_inventory.money}";
    }
}