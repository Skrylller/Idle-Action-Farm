using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesArea : MonoBehaviour
{
    [SerializeField] private Transform _salesPoint;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _inventory.SaleInventory(_salesPoint);
        }
    }
}
