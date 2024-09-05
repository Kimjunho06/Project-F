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

        getObjLayer = _player.getObjLayer;

        Collider2D[] getObj = GetObjects();
        if (getObj != null)
        {
            foreach (Collider2D obj in getObj)
            {
                if (obj.TryGetComponent<Soil>(out Soil soil))
                {
                    if (soil.cropBase.isHarvestable)
                    {
                        soil.cropBase.Harvest();
                        break;
                    }
                }
            }
            getObj = null;
        }
        // 플레이어 범위에 아이템 있으면 먹기
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

    }
}
