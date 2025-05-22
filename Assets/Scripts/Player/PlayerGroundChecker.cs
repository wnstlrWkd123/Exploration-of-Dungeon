using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    private float checkDistance = 1f;

    [SerializeField] private LayerMask groundLayer;
    private Transform ray;

    private void Awake()
    {
        ray = transform;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(ray.position, Vector3.down, checkDistance, groundLayer);
    }
}
