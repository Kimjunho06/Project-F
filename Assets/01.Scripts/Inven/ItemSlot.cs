using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Item currentItem = null;
    public Item CurrentItem
    {
        get { return currentItem; }
        set { currentItem = value; }
    }

    private int currentStackCount = 0;
    public int CurrentStackCount
    {
        get { return currentStackCount; }
        set { currentStackCount = value; }
    }

    public TextMeshProUGUI stackText = null;
    public Image image = null;

    private void Awake()
    {
        stackText = GetComponentInChildren<TextMeshProUGUI>();
        image = transform.GetChild(1).GetComponent<Image>();
        image.sprite = currentItem.ItemData.ItemImage;
        image.color = Color.clear;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (currentItem.ItemData.ItemType == ItemType.Interectable)
        {
            Use();
        }
    }

    public void Use()
    {
        if (currentStackCount > 0)
        {

            currentStackCount--;
            currentItem.Use();

            if (currentStackCount <= 0)
            {
                Inventory.instance.ItemList.Remove(currentItem);
                currentItem = Inventory.instance.NoneItem;
                image.sprite = currentItem.ItemData.ItemImage;
                image.color = Color.clear;
            }
        }
        stackText.text = currentStackCount == 0 ? string.Empty : $"{currentStackCount}";
    }

    public void AddItem()
    {
        currentStackCount++;
        stackText.text = $"{currentStackCount}";
    }

    public void SetItem(Item item, int count)
    {
        currentItem = item;
        currentStackCount = count;
        image.sprite = currentItem.ItemData.ItemImage;
        image.color = Color.white;

        stackText.text = currentStackCount == 0 ? string.Empty : $"{currentStackCount}";
    }
}