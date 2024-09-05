using UnityEngine;

public enum Type
{
    Interectable,
    Default,
    None
}

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite ItemImage { get; private set; }
    [field: SerializeField] public int StackCount { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public Type ItemType { get; private set; }
}