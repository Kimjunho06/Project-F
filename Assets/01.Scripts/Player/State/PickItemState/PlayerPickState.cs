using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickState : PlayerState
{
    protected Vector3 getObjoffset;
    protected Vector3 getObjSize;
    protected LayerMask getObjLayer;




    public PlayerPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _player.StopImmediately();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        // 상호작용 중 움직이면 취소.
        if (Mathf.Abs(_player.xInput) > 0.05f || Mathf.Abs(_player.yInput) > 0.05f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);

        // 애니메이션 끝나면 돌아가기.
        if (_endtriggerCalled)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }

    // Update에서 해주면 모든 각도 오브젝트 가져옴.
    public Collider2D[] GetObject()
    {
        Vector3 pos = _player.transform.position + _player.prevInput.normalized;
        Vector3 size = new Vector3(2, 1, 0);
        float angle = GetAngle();

        Collider2D[] objects = Physics2D.OverlapBoxAll(pos, size, angle, getObjLayer);
        return objects;
    }

    private float GetAngle()
    {
        Vector3 dir = _player.prevInput.normalized;
        float dot = Vector3.Dot(_player.transform.right * _player.FacingDirection, dir);

        float minAngle = (_player.prevInput.y < 0) ? -1 : 1;

        return Mathf.Acos(dot) * Mathf.Rad2Deg * minAngle;
    }
}
