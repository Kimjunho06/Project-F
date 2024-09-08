using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoneItemPickState : PlayerPickState
{


    public PlayerNoneItemPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
                if (obj.TryGetComponent<Item>(out Item item))
                {
                    Inventory.instance.AddItem(item);
                    InventoryBar.instance.RedrawInven();
                    if (item.ItemData.ItemType != ItemType.Seed && item.ItemData.ItemType != ItemType.Fertilizer)
                        item.gameObject.SetActive(false); // 먹은 아이템 삭제 . 풀만들면 바꿀거임 아마도

                    break;
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

    }
}
