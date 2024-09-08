using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    public List<ItemSlot> slots = new List<ItemSlot>();

    private Player _player;
    private Inventory inventory;
    public int curIndex;

    public static InventoryBar instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        inventory = Inventory.instance;
        curIndex = 0;
    }

    private void Update()
    {
        if (inventory.ItemList.Count > 0)
        {
            for (int i = 0; i < slots.Count && i < inventory.ItemList.Count; i++)
            {
                slots[i].SetItem(inventory.ItemList[i], inventory.Slots[i].CurrentStackCount);
            }
        }

        SetItemInputNum();
    }

    private void SetItemInputNum()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curIndex = 0;
            _player.SetCurrentItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curIndex = 1;
            _player.SetCurrentItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curIndex = 2;
            _player.SetCurrentItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curIndex = 3;
            _player.SetCurrentItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            curIndex = 4;
            _player.SetCurrentItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            curIndex = 5;
            _player.SetCurrentItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            curIndex = 6;
            _player.SetCurrentItem(6);
        }
    }

    public void UseItem(int value)
    {
        if (inventory.ItemList.Count > curIndex)
        {
            if (slots[curIndex].CurrentStackCount - value <= 0)
            {
                Inventory.instance.Slots[curIndex].SetItem(_player.currentItem, 1);
                if (slots[curIndex].CurrentItem.ItemData.ItemType == ItemType.Seed || slots[curIndex].CurrentItem.ItemData.ItemType == ItemType.Fertilizer)
                {
                    Inventory.instance.Slots[curIndex].Use();
                    slots[curIndex].CurrentItem = inventory.NoneItem;
                    Inventory.instance.RedrawInven();
                    RedrawInven();
                }
            }
            else
                Inventory.instance.Slots[curIndex].SetItem(_player.currentItem, slots[curIndex].CurrentStackCount - value);
        }
    }

    public void RedrawInven()
    {
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(Inventory.instance.NoneItem, Inventory.instance.NoneItem.ItemData.StackCount);
        }

        for (int i = 0; i < Inventory.instance.ItemList.Count; i++)
        {
            foreach (ItemSlot slot in slots)
            {
                if (slot.CurrentItem.ItemData.ItemName == Inventory.instance.ItemList[i].ItemData.ItemName) //이미 있으면 스택에 추가
                    if (slot.CurrentStackCount < Inventory.instance.ItemList[i].ItemData.StackCount)
                    {
                        slot.AddItem();
                        break;
                    }
                if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //없으면 생성
                {
                    slot.SetItem(Inventory.instance.ItemList[i], 1);
                    break;
                }
            }
        }
    }
}
