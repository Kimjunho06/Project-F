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

        // 밑, 앞 땅이 갈아져 있으면 기름진 땅
        // 물까지 있다면 기름진 물 땅
        // 아니라면 리턴

        // 개수 소모

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
