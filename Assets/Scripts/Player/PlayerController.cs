using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private bool jumpInput = false;
    Ray cursorSensorPosition;

    private PlayerControls controls;
    private Player player;
    private PlayerGroundChecker groundChecker;
    private PlayerCursorSensor cursorSensor;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        controls = new PlayerControls(); // C# 스크립트
        player = GetComponent<Player>();
        groundChecker = GetComponent<PlayerGroundChecker>();
        cursorSensor = GetComponent<PlayerCursorSensor>();
        _rigidbody = GetComponent<Rigidbody>();

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

    private void Update()
    {
        Check();
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
        if (horizontalVelocity.magnitude < player.MaxSpeed)
        {
            _rigidbody.AddForce(moveDir * player.Accelerate, ForceMode.Acceleration);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<float>() == 1f;
    }

    private void Jump()
    {
        if (jumpInput && groundChecker.IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * player.JumpPower, ForceMode.Impulse);
        }
    }

    private void Check()
    {
        cursorSensorPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        cursorSensor.IsInteraction(cursorSensorPosition);
    }
}
