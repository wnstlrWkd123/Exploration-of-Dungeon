using System.Collections;
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
    private float additionalMaxSpeed = 0f; // 추가 최대속도
    public float MaxSpeed => maxSpeed + additionalMaxSpeed;

    private float jumpPower = 2f; // 점프력
    private float additionalJumpPower = 0f; // 추가 점프력
    public float JumpPower => jumpPower + additionalJumpPower;

    private void Awake()
    {
        currentHitPoint = maxHitPoint;
    }

    private void OnEnable()
    {
        EventBus.Subscribe("Heal", Heal);
        EventBus.Subscribe("TakeDamage", TakeDamage);
        EventBus.Subscribe("SpeedBuff", (object data) => SpeedBuff((BuffData)data));
        EventBus.Subscribe("JumpBuff", (object data) => JumpBuff((BuffData)data));
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("Heal", Heal);
        EventBus.Unsubscribe("TakeDamage", TakeDamage);
        EventBus.Unsubscribe("SpeedBuff", (object data) => SpeedBuff((BuffData)data));
        EventBus.Unsubscribe("JumpBuff", (object data) => JumpBuff((BuffData)data));
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

    private void SpeedBuff(BuffData data)
    {
        StartCoroutine(SpeedBuffRoutine(data.value, data.duration));
    }

    private IEnumerator SpeedBuffRoutine(float value, float duration)
    {
        additionalMaxSpeed += value;
        yield return new WaitForSeconds(duration);
        additionalMaxSpeed -= value;
    }

    private void JumpBuff(BuffData data)
    {
        StartCoroutine(JumpBuffRoutine(data.value, data.duration));
    }

    private IEnumerator JumpBuffRoutine(float value, float duration)
    {
        additionalJumpPower += value;
        yield return new WaitForSeconds(duration);
        additionalJumpPower -= value;
    }
}
