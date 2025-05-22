using UnityEngine;

public class HitPointItem : ConsumableItem
{
    [SerializeField] private float value;

    public override void UseItem()
    {
        EventBus.Publish("Heal", value);

        if (--itemCount == 0) Destroy(gameObject);
    }
}
