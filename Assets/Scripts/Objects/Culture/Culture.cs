using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Culture : MonoBehaviour
{
    [SerializeField] private CultureObject _cultureObj;
    [SerializeField] private ParticleSystem _particles;
    public CultureObject cultureObj { get { return _cultureObj; } }

    [SerializeField] private GameObject HasGrownModel;
    [SerializeField] private GameObject DestroyModel;

    private BoxCollider _collider;
    private bool _isHasGrown;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();

        ChangeStateCulture(true);
    }

    public void ChangeStateCulture(bool hasGrown)
    {
        _isHasGrown = hasGrown;
        UpdateModel();

        if (hasGrown == false)
            StartCoroutine(HasGrownTimer());
    }

    private void UpdateModel()
    {
        _collider.enabled = _isHasGrown;
        HasGrownModel.SetActive(_isHasGrown);
        DestroyModel.SetActive(!_isHasGrown);
        _particles.gameObject.SetActive(!_isHasGrown);
    }

    private IEnumerator HasGrownTimer()
    {
        yield return new WaitForSeconds(cultureObj.timeToHasGrown);
        ChangeStateCulture(true);
    }

}
