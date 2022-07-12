using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneComponentsManager : MonoBehaviour
{
    public static SingletoneComponentsManager main { get; private set; }

    [SerializeField] private PlayerController _player;
    [SerializeField] private UIController _uIController;
    public PlayerController player { get { return _player; }}
    public UIController uIController { get { return _uIController; }}

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
