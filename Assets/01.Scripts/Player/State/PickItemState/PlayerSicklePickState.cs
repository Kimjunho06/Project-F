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

        // �� ���� üũ �� �� �ڶ� �ֵ� ��Ȯ
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
