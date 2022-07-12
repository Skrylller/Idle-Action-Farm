using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private GameObject HasGrownModel;
    [SerializeField] private GameObject DestroyModel;

    private bool _isHasGrown;

    private void Start()
    {
        ChangeStateWheat(true);
    }

    public void ChangeStateWheat(bool hasGrown)
    {
        _isHasGrown = hasGrown;
        UpdateModel();
    }

    private void UpdateModel()
    {
        HasGrownModel.SetActive(_isHasGrown);
        DestroyModel.SetActive(!_isHasGrown);
    }

    private IEnumerator HasGrownTimer()
    {

    }
}
