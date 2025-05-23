using UnityEngine;

internal enum BuffType
{
    Speed,
    Jump
}

public class BuffItem : ConsumableItem
{
    [SerializeField] private BuffType type;
    [SerializeField] private float value;
    [SerializeField] private float duration;

    public override void UseItem()
    {
        switch (type)
        {
            case BuffType.Speed:
                EventBus.Publish("SpeedBuff", new BuffData(value, duration));
                break;
            case BuffType.Jump:
                EventBus.Publish("JumpBuff", new BuffData(value, duration));
                break;
        }

        if (--itemCount == 0) Destroy(gameObject);
    }
}
