using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPulls : MonoBehaviour
{
    [SerializeField] private Pull cultures;
    [SerializeField] private Pull moneys;

    private CultureStackDetector _stackDetector;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _stackDetector = SingletoneComponentsManager.main.cultureStackDetector;
    }

    public void ActivateMoney(Vector3 position, int cost)
    {
        moneys.ActivateObject(_camera.WorldToScreenPoint(position), new Vector3()).GetComponent<MoneyEffect>().Init(cost);
    }

    public void ActivateCultureStack(Vector3 position, CultureObject cultureObject)
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

    [SerializeField] private Transform parrent;

    public GameObject FindFreeObject()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].activeSelf == false)
                return _objects[i];
        }

        _objects.Add(GameObject.Instantiate(_objectPrefab, parrent));
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