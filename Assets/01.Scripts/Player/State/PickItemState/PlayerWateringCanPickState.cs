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

        // 밑, 앞에 땅이 갈아져 있으면 젖은 땅
        // 앞에 물이면 수분 채우기
    }

    public override void Exit()
    {
        base.Exit();
        // 수분줄이기
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
