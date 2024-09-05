using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNonePickState : PlayerPickState
{
    public PlayerNonePickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        getObjLayer = LayerMask.GetMask("Test");

        foreach (var a in GetObject())
        {
            Debug.Log(a.name);
        }

        // �ƹ��͵� ���ٸ� �ּ��ּ�
        // �÷��̾� �Ʒ�, �� ������ ������ ������ �Ա�
        // �÷��̾� �Ʒ�, �� ������ ��簡 �� �� ���� �ִٸ� �Ա�
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
