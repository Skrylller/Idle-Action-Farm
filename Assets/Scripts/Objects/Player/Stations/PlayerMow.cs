using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMow : _PlayerState
{
    [SerializeField] private AnimationClip animClip;

    public override void InitState(PlayerController playerController)
    {
        base.InitState(playerController);

        playerController.StartCoroutine(AnimationTimer());
    }

    private IEnumerator AnimationTimer()
    {
        yield return new WaitForSeconds(animClip.length);

        _playerController.SetState(_playerController.idleState, changeAnyway: true);
    }
}
