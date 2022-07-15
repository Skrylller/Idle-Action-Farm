using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class _PlayerState
{
    protected PlayerController _playerController;

    [SerializeField] private int _animationId;
    public int animationId { get { return _animationId; }}

    public virtual void StateUpdate() { }
    public virtual void StateFUpdate() { }

    public virtual void InitState(PlayerController playerController)
    {
        _playerController = playerController;
    }
}
