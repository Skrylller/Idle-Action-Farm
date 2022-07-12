using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerIdle _idleState = new PlayerIdle();
    [SerializeField] private PlayerWalk _walkState = new PlayerWalk();
    [SerializeField] private PlayerMow _mowState = new PlayerMow();

    public PlayerIdle idleState { get { return _idleState; } }
    public PlayerWalk walkState { get { return _walkState; } }
    public PlayerMow mowState { get { return _mowState; } }


    private _PlayerState _state;

    [SerializeField] private Animator _animator;

    private void Start()
    {
        SetState(_idleState);
    }

    private void Update()
    {
        _state.StateUpdate();
    }

    private void FixedUpdate()
    {
        _state.StateFUpdate();
    }


    public void SetState(_PlayerState state, bool changeAnyway = false)
    {
        if ((_state == state || _state == mowState) && !changeAnyway)
            return;

        _state = state;
        _state.InitState(this);
        _animator.SetInteger(_animator.parameters[0].name, state.animationId);
    }

    public void StartCoroutineState(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
