using UnityEngine;

public class JumpHelper : MonoBehaviour
{
    private float bounceForce = 25f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody _rigidbody = other.attachedRigidbody;
        if (_rigidbody != null)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z); // 기존 Y 속도 제거
            _rigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse); // 즉시 튕겨올림
        }
    }
}
