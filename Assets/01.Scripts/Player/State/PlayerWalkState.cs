using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Windows;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // Init Anim
        SetMoveAnimParam(0, 0, false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        float xInput = _player.PlayerInput.XInput;
        float yInput = _player.PlayerInput.YInput;

        SetMoveAnimParam(xInput, yInput, false);

        Move(xInput, yInput);

        if (Mathf.Abs(xInput) < 0.05f && Mathf.Abs(yInput) < 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    private void SetMoveAnimParam(float xInput, float yInput, bool isLerp = true)
    {
        _player.AnimatorCompo.SetBool("Run", _player.PlayerInput.IsDash);

        if (isLerp)
        {
            _player.AnimatorCompo.SetFloat("XInput", xInput, 0.2f, Time.deltaTime);
            _player.AnimatorCompo.SetFloat("YInput", yInput, 0.2f, Time.deltaTime);
        }
        else
        {
            _player.AnimatorCompo.SetFloat("XInput", xInput);
            _player.AnimatorCompo.SetFloat("YInput", yInput);
        }
    }

    private void Move(float xInput, float yInput)
    {
        Vector2 moveDir = new Vector2(xInput, yInput).normalized;

        if (_player.PlayerInput.IsDash)
            moveDir *= _player.dashSpeed;
        else
            moveDir *= _player.moveSpeed;

        _player.SetVelocity(moveDir);
    }
}
