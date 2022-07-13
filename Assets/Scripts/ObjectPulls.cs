using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPulls : MonoBehaviour
{
    private CultureStackDetector _stackDetector;

    [SerializeField] private Pull cultures;

    private void Start()
    {
        _stackDetector = SingletoneComponentsManager.main.cultureStackDetector;
    }

    public void ActivateCulture(Vector3 position, CultureObject cultureObject)
    {
        CultureStack culture = cultures.ActivateObject(position, new Vector3()).GetComponent<CultureStack>();
        culture.Init(cultureObject);
        _stackDetector.AddStack(culture);
    }
}


[System.Serializable]
public class Pull
{
    [SerializeField] private GameObject _objectPrefab;

    private List<GameObject> _objects = new List<GameObject>();

    public GameObject FindFreeObject()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].activeSelf == false)
                return _objects[i];
        }

        _objects.Add(GameObject.Instantiate(_objectPrefab));
        _objects[_objects.Count - 1].SetActive(false);

        return _objects[_objects.Count - 1];
    }

    public GameObject ActivateObject(Vector3 position, Vector3 rotation)
    {
        GameObject obj = FindFreeObject();
        obj.transform.position = position;
        obj.transform.eulerAngles = rotation;
        obj.SetActive(true);

        return obj;
    }
}