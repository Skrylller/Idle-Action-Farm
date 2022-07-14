using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBag : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private List<GameObject> _objectsInBag = new List<GameObject>();

    private void OnEnable()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
        _inventory.UpdateInventory += SetInventory;
    }

    private void OnDisable()
    {
        _inventory.UpdateInventory -= SetInventory;
    }

    public void SetInventory()
    {
        int occupancy = (int)((float)_inventory.cultureCount / _inventory.playerStats.inventorySize * _objectsInBag.Count);
        occupancy = occupancy <= 0 && _inventory.cultureCount > 0 ? 1 : occupancy;

        for(int i = 0; i < _objectsInBag.Count; i++)
        {
            _objectsInBag[i].SetActive(i <= occupancy - 1);
        }
    }
}
