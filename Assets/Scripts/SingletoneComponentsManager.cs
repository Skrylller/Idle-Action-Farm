using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneComponentsManager : MonoBehaviour
{
    public static SingletoneComponentsManager main { get; private set; }

    [SerializeField] private PlayerController _player;
    [SerializeField] private UIController _UIController;
    [SerializeField] private ObjectPulls _objectPulls;
    [SerializeField] private CultureStackDetector _cultureStackDetector;
    [SerializeField] private Inventory _inventory = new Inventory();
    public PlayerController player { get { return _player; }}
    public UIController UIController { get { return _UIController; } }
    public ObjectPulls objectPulls { get { return _objectPulls; } }
    public CultureStackDetector cultureStackDetector { get { return _cultureStackDetector; } }
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
