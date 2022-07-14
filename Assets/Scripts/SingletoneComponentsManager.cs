using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneComponentsManager : MonoBehaviour
{
    public static SingletoneComponentsManager main { get; private set; }

    [SerializeField] private ObjectPulls _objectPulls;
    [SerializeField] private CultureStackDetector _cultureStackDetector;
    [SerializeField] private InputSystem _input;
    [SerializeField] private Inventory _inventory = new Inventory();
    public ObjectPulls objectPulls { get { return _objectPulls; } }
    public CultureStackDetector cultureStackDetector { get { return _cultureStackDetector; } }
    public InputSystem input { get { return _input; } }
    public Inventory inventory { get { return _inventory; } }

    private void Awake()
    {
        if (main != null)
        {
            Debug.LogError("extra singleton instance");
            Destroy(main);
        }
        main = this;
    }
}
