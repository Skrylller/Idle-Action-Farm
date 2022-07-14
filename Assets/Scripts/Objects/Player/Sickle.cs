using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    private ObjectPulls _objectPulls;

    private void Start()
    {
        _objectPulls = SingletoneComponentsManager.main.objectPulls;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Culture")
        {
            Culture culture = other.GetComponent<Culture>();
            culture.ChangeStateCulture(false);
            _objectPulls.ActivateCultureStack(other.transform.position, culture.cultureObj);
        }
    }
}
