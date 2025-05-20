using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    private float checkDistance = 1f;

    [SerializeField] private LayerMask groundLayer;
    private Transform rayOrigin;

    private void Awake()
    {
        rayOrigin = transform;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(rayOrigin.position, Vector3.down, checkDistance, groundLayer);
    }
}
