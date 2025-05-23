using UnityEngine;

public enum ItemType
{
    Resource,
    Consumable
}

public class Item : MonoBehaviour
{
    public ItemData itemData;
    public ItemType itemType; 
}
