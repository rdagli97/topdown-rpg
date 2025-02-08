using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = .2f;
    private Vector2 moveInput;
    private CharacterController characterController;
    private IA_PlayerInput playerInput;
    private Vector3 moveDirection;

    private float dashTime;
    private bool isDashing;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = new IA_PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        playerInput.Player.Dash.performed += ctx => Dash();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        if(isDashing)
        {
            characterController.Move(moveDirection * dashSpeed * Time.deltaTime);

            if(Time.time > dashTime)
                isDashing = false;
        } else
        {
            Vector3 _moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
            moveDirection = _moveDirection;
            characterController.Move(_moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void Dash()
    {
        if (isDashing) return;

        isDashing = true;
        dashTime = Time.time + dashDuration;
        Debug.Log("Dash performed");
    }
}
