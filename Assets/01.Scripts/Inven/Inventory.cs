using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> slots = new List<ItemSlot>(); //���Ը���Ʈ
    public List<ItemSlot> Slots => slots;
    [field: SerializeField] public Item NoneItem { get; private set; }
    [field: SerializeField] public List<Item> ItemList { get; private set; } //������ ������ ����Ʈ
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
        GetComponentsInChildren<ItemSlot>(slots); //�κ��丮 ã�ƿ���
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
                if (slot.CurrentItem.ItemData.ItemName == ItemList[i].ItemData.ItemName) //�̹� ������ ���ÿ� �߰�
                    if (slot.CurrentStackCount < ItemList[i].ItemData.StackCount)
                    {
                        slot.AddItem();
                        break;
                    }
                if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //������ ����
                {
                    slot.SetItem(ItemList[i], 1);
                    break;
                }
            }
        }
    }

    public void AddItem(Item item) //���Կ� ������ �߰��ϱ�
    {
        ItemList.Add(item);
        foreach (ItemSlot slot in slots)
        {
            if (slot.CurrentItem.ItemData.ItemName == item.ItemData.ItemName) //�̹� ������ ���ÿ� �߰�
                if (slot.CurrentStackCount < item.ItemData.StackCount)
                {
                    slot.AddItem();
                    break;
                }
            if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //������ ����
            {
                slot.SetItem(item, 1);
                break;
            }
        }
    }
}