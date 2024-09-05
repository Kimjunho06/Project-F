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

        // 잡은 씨앗 이미지 정해주기

        // 밑, 앞 범위에 땅이 안갈려있으면 Idle하고 리턴

        // 잡은 씨앗 개수 줄이기

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
