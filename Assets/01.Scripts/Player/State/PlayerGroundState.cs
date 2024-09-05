using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.InteractionEvent += InteractTool;
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.InteractionEvent -= InteractTool;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
    
    // 플레이어가 들고 있는 아이템의 상태로 바꿔주기
    private void InteractTool()
    {
        string curItemString = $"{_player.currentItem}Pick";
        PlayerStateEnum changeStateEnum = (PlayerStateEnum)Enum.Parse(typeof(PlayerStateEnum), curItemString);

        _player.StateMachine.ChangeState(changeStateEnum);
    }
}
