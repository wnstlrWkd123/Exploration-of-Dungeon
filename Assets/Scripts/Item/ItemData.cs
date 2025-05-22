using UnityEngine;

public enum ItemType
{
    Consumable,
    Resource
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public ItemType itemType;
}
