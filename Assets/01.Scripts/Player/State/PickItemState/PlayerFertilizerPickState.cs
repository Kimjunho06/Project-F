using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFertilizerPickState : PlayerPickState
{
    public PlayerFertilizerPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // ��, �� ���� ������ ������ �⸧�� ��
        // ������ �ִٸ� �⸧�� �� ��
        // �ƴ϶�� ����

        // ���� �Ҹ�

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
