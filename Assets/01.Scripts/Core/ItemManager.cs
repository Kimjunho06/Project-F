using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public List<ItemSO> items;
    public Item itemPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnItem("´ç±Ù", Vector2.zero);
        }
    }

    public void SpawnItem(string itemName, Vector2 pos)
    {
        foreach (var item in items)
        {
            if (item.ItemName == itemName)
            {
                GameObject obj = Instantiate(itemPrefab.gameObject);

                obj.transform.position = pos;
                obj.SetActive(true);
                if (obj.TryGetComponent<Item>(out Item itemObj))
                {
                    itemObj.ItemData = item;
                }
            }
        }
    }
}
