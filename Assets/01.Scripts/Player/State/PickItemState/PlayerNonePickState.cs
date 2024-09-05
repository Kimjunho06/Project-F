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

        // 아무것도 없다면 주섬주섬
        // 플레이어 아래, 앞 범위에 아이템 있으면 먹기
        // 플레이어 아래, 앞 범위에 농사가 다 된 것이 있다면 먹기
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
