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
                break;
            case BuffType.Jump:
                break;
        }

        if (--itemCount == 0) Destroy(gameObject);
    }
}
