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

        getObjLayer = _player.getObjLayer;

        Collider2D[] getObj = GetObjects();
        if (getObj != null)
        {
            foreach (Collider2D obj in getObj)
            {
                if (obj.TryGetComponent<Soil>(out Soil soil))
                {
                    if (!soil.currentState.HasFlag(SoilState.Wet))
                    {
                        soil.Water();
                        break;
                    }
                }
            }
            getObj = null;
        }
        // 수분줄이기

        getObjLayer = LayerMask.GetMask("Water");
        Collider2D[] getWater = GetObjects();
        if (getWater != null)
            Debug.Log("수분채움.");
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
