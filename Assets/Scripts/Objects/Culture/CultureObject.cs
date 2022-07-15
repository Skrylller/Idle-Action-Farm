using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/CultureObject")]
public class CultureObject : ScriptableObject
{
    [SerializeField] private int _costCulture;
    [SerializeField] private float _timeToHasGrown;

    public int costCulture { get { return _costCulture; } }
    public float timeToHasGrown { get { return _timeToHasGrown; } }
}
