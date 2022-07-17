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

    public _PlayerState state { get; private set; }

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
        state.StateUpdate();
    }

    private void FixedUpdate()
    {
        state.StateFUpdate();
    }

    public void SetState(_PlayerState state, bool changeAnyway = false)
    {
        if ((this.state == state || this.state == mowState) && !changeAnyway)
            return;

        this.state = state;
        this.state.InitState(this);
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
