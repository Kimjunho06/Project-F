using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSicklePickState : PlayerPickState
{
    public PlayerSicklePickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // 앞 범위 체크 후 다 자란 애들 수확
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    protected override void InteractItem()
    {
        _endtriggerCalled = true;
    }
}
