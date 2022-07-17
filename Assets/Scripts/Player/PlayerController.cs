using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerIdle _idleState = new PlayerIdle();
    [SerializeField] private PlayerWalk _walkState = new PlayerWalk();
    [SerializeField] private PlayerMow _mowState = new PlayerMow();

    public PlayerStats playerStats { get { return _playerStats; } }
    public PlayerIdle idleState { get { return _idleState; } }
    public PlayerWalk walkState { get { return _walkState; } }
    public PlayerMow mowState { get { return _mowState; } }

    private _PlayerState _state;

    [SerializeField] private Animator _animator;
    private InputSystem _input;

    private void Start()
    {
        SetState(idleState);
        SingletoneComponentsManager.main.inventory.Init(_playerStats);
        SingletoneComponentsManager.main.cultureStackDetector.Init(_playerStats);
    }

    private void OnEnable()
    {
        _input = SingletoneComponentsManager.main.input;
        _input.InputGetTouch += SetWalk;
        _input.InputGetTouchUp += SetIdle;
    }

    private void OnDisable()
    {
        _input.InputGetTouch -= SetWalk;
        _input.InputGetTouchUp -= SetIdle;
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

    public bool CheckAnimationClip(AnimationClip clip)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(clip.name);
    }

    public void StartCoroutineState(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    private void SetWalk()
    {
        SetState(walkState);
        walkState.SetDirectional(_input.currentTouchPosition, _input.startTouchPosition);
    }
    private void SetIdle()
    {
        SetState(idleState);
        walkState.SetDirectional(new Vector3(0,0,0));
    }

}
