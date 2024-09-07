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
                        if (Inventory.instance.Slots[InventoryBar.instance.curIndex].CurrentStackCount > 0)
                        {
                            soil.Water();
                            break;
                        }
                    }
                }
            }
            getObj = null;
        }

        InventoryBar.instance.UseItem(10);
        
        getObjLayer = _player.whatIsWater;
        Collider2D[] getWater = GetObjects();

        if (getWater.Length > 0)
        {
            int maxCnt = _player.currentItem.ItemData.StackCount;
            Inventory.instance.Slots[InventoryBar.instance.curIndex].SetItem(_player.currentItem, maxCnt);
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
