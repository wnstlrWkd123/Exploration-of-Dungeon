using UnityEngine;

public enum ConsumableType
{
    HitPoint,
    Buff
}

public class ConsumableItem : Item
{
    [SerializeField] protected int itemCount;
    [SerializeField] protected ConsumableType consumableType;

    public virtual void UseItem()
    {

    }
}
