using UnityEngine;

public enum ItemType
{
    NoneItem = 0,
    Seed,
    WateringCan,
    Fertilizer,
    Sickle,
    // ¿Ã πÿ∑Œ Ω·¡÷º¿..
    Interectable,
    Default,
}

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite ItemImage { get; private set; }
    [field: SerializeField] public int StackCount { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
}