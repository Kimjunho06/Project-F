using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWateringCanPickState : PlayerPickState
{
    public PlayerWateringCanPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // ��, �տ� ���� ������ ������ ���� ��
        // �տ� ���̸� ���� ä���
    }

    public override void Exit()
    {
        base.Exit();
        // �������̱�
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
