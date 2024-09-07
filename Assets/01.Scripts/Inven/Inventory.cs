using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> slots = new List<ItemSlot>(); //슬롯리스트
    public List<ItemSlot> Slots => slots;
    [field: SerializeField] public Item NoneItem { get; private set; }
    [field: SerializeField] public List<Item> ItemList { get; private set; } //소지한 아이템 리스트
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int slotCnt;
    [SerializeField] private Transform rootObj;

    public static Inventory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < slotCnt; i++)
        {
            var obj = Instantiate(slotPrefab);
            obj.transform.SetParent(rootObj);
        }
        GetComponentsInChildren<ItemSlot>(slots); //인벤토리 찾아오기
    }



    public void RedrawInven()
    {
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(NoneItem, NoneItem.ItemData.StackCount);
        }

        for (int i = 0; i < ItemList.Count; i++)
        {
            foreach (ItemSlot slot in slots)
            {
                if (slot.CurrentItem.ItemData.ItemName == ItemList[i].ItemData.ItemName) //이미 있으면 스택에 추가
                    if (slot.CurrentStackCount < ItemList[i].ItemData.StackCount)
                    {
                        slot.AddItem();
                        break;
                    }
                if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //없으면 생성
                {
                    slot.SetItem(ItemList[i], 1);
                    break;
                }
            }
        }
    }

    public void AddItem(Item item) //슬롯에 아이템 추가하기
    {
        ItemList.Add(item);
        foreach (ItemSlot slot in slots)
        {
            if (slot.CurrentItem.ItemData.ItemName == item.ItemData.ItemName) //이미 있으면 스택에 추가
                if (slot.CurrentStackCount < item.ItemData.StackCount)
                {
                    slot.AddItem();
                    break;
                }
            if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //없으면 생성
            {
                slot.SetItem(item, 1);
                break;
            }
        }
    }
}