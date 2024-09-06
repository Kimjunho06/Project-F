using UnityEngine;

public enum ItemType
{
    NoneItem = 0,
    CropSeed,
    WateringCan,
    Fertilizer,
    Sickle,
    Crop,
    // 이 줄에 추가하삼..
    Interectable,
    Default,
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite ItemImage { get; private set; }
    [field: SerializeField] public int StackCount { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
}