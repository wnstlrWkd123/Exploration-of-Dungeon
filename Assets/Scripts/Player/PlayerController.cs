using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveAccel = 10f;
    private float maxSpeed = 10f;
    private float jumpPower = 2f;
    private bool jumpInput = false;

    private PlayerControls controls;
    private Rigidbody _rigidbody;
    private Vector2 moveInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        controls = new PlayerControls(); // new로해도 좋은가요?

        //나중에 팩토리패턴으로
        controls.Player.Move.started += OnMove;
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Jump.started += OnJump;
        controls.Player.Jump.performed += OnJump;
        controls.Player.Jump.canceled += OnJump;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        // 현재 속도
        Vector3 velocity = _rigidbody.velocity;
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);

        // 속도 제한
        if (horizontalVelocity.magnitude < maxSpeed)
        {
            _rigidbody.AddForce(moveDir * moveAccel, ForceMode.Acceleration);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<float>() == 1f;
    }

    private void Jump()
    {
        // && Raycast에 닿는다면 점프 ㄱㄱ
        if (jumpInput)
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
