using UnityEngine;

internal enum HitPointItemType
{
    Good,
    Bad
}

public class HitPointItem : ConsumableItem
{
    [SerializeField] private HitPointItemType type;
    [SerializeField] private float value;

    public override void UseItem()
    {
        switch (type)
        {
            case HitPointItemType.Good:
                EventBus.Publish("Heal", value);
                break;
            case HitPointItemType.Bad:
                EventBus.Publish("TakeDamage", value);
                break;
        }

        if (--itemCount == 0) Destroy(gameObject);
    }
}
