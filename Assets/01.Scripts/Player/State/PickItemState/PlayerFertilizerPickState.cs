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

        getObjLayer = _player.getObjLayer;

        Collider2D[] getObj = GetObjects();
        if (getObj != null)
        {
            foreach (Collider2D obj in getObj)
            {
                if (obj.TryGetComponent<Soil>(out Soil soil))
                {
                    if (!soil.currentState.HasFlag(SoilState.Fertile))
                    {
                        soil.Fertilize();
                        // 개수 소모
                        break;
                    }
                }
            }
            getObj = null;
        }
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
