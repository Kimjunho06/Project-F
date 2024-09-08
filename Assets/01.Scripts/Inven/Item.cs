using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO itemData;
    public ItemSO ItemData
    {
        get { return itemData; }
        set {  itemData = value; }
    }

    private SpriteRenderer spriteRenderer;

    [SerializeField] ItemEffect[] effect;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = itemData.ItemImage;
    }

    public void Use()
    {
        for (int i = 0; i < effect.Length; i++)
        {
            effect[i].Effect();
        }
    }
}

