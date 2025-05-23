using UnityEngine;

public enum ConsumableType
{
    HitPoint,
    Buff
}

public class ConsumableItem : Item
{
    [SerializeField] protected ConsumableType consumableType;
    [SerializeField] protected int itemCount;

    public virtual void UseItem()
    {

    }
}
