using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _magneticDistance;
    [SerializeField] private float _takeDistance;
    [SerializeField] private int _inventorySize;

    public float walkSpeed { get { return _walkSpeed; } }
    public float magneticDistance { get { return _magneticDistance; } }
    public float takeDistance { get { return _takeDistance; } }
    public int inventorySize { get { return _inventorySize; } }

}
