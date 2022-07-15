using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureStackDetector : MonoBehaviour
{
    [SerializeField] private List<CultureStack> _cultureStackComponents = new List<CultureStack>();

    private PlayerStats _playerStats;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = SingletoneComponentsManager.main.inventory;
    }

    private void Update()
    {
        CheckPlayerDistanceForStacks();
    }

    public void Init(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    public void AddStack(CultureStack stack)
    {
        _cultureStackComponents.Add(stack);
    }

    private void CheckPlayerDistanceForStacks()
    {
        for (int i = 0; i < _cultureStackComponents.Count; i++)
        {
            if (_inventory.FreeInventory() == false)
                return;

            float distance = Vector3.Distance(transform.position, _cultureStackComponents[i].transform.position);

            if (distance < _playerStats.takeDistance)
            {
                _cultureStackComponents[i].TakeStack();
                _inventory.PlusCulture(_cultureStackComponents[i].cultureObject);
                _cultureStackComponents.Remove(_cultureStackComponents[i]);
                i--;
                break;
            }
            else if (distance < _playerStats.magneticDistance)
            {
                _cultureStackComponents[i].MagneticToTarget(transform.position);
            }
        }
    }
}
