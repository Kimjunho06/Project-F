using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedPickState : PlayerPickState
{

    CropSO crop;
    public PlayerSeedPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        getObjLayer = _player.getObjLayer;

        // ���� ���� �̹��� �����ֱ�

        // ��, �� ������ ���� �Ȱ��������� Idle�ϰ� ����

        // ���� ���� ���� ���̱�

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    protected override void InteractEndItem()
    {
        _endtriggerCalled = true;
    }
}
