using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBag : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsInBag = new List<GameObject>();

    public void SetInventory(int countObjects, int maxCount)
    {
        int occupancy = (int)((float)countObjects / maxCount * _objectsInBag.Count);

        for(int i = 0; i < _objectsInBag.Count; i++)
        {
            _objectsInBag[i].SetActive(i <= occupancy - 1);
        }
    }
}
