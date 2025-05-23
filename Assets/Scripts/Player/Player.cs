using UnityEngine;

public class Player : MonoBehaviour
{
    private float maxHitPoint = 100f; // 체력
    public float MaxHitPoint
    {
        get { return maxHitPoint; }
    }

    private float currentHitPoint; // 체력
    public float CurrentHitPoint
    {
        get { return currentHitPoint; }
    }

    private float accelerate = 10f; // 가속도
    public float Accelerate
    {
        get { return accelerate; }
    }

    private float maxSpeed = 10f; // 최대속도
    public float MaxSpeed
    {
        get { return maxSpeed; }
    }

    private float jumpPower = 2f; // 점프력
    public float JumpPower
    {
        get { return jumpPower; }
    }

    private void Awake()
    {
        currentHitPoint = maxHitPoint;
    }

    private void OnEnable()
    {
        EventBus.Subscribe("Heal", Heal);
        EventBus.Subscribe("TakeDamage", TakeDamage);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("Heal", Heal);
        EventBus.Unsubscribe("TakeDamage", TakeDamage);
    }

    public void Heal(object value)
    {
        currentHitPoint += (float)value;
        currentHitPoint = Mathf.Clamp(currentHitPoint, 0, maxHitPoint);

        EventBus.Publish("PlayerHitPointChanged", currentHitPoint / maxHitPoint);
    }

    public void TakeDamage(object damage)
    {
        currentHitPoint -= (float)damage;
        currentHitPoint = Mathf.Clamp(currentHitPoint, 0, maxHitPoint);

        EventBus.Publish("PlayerHitPointChanged", currentHitPoint / maxHitPoint);
    }
}
