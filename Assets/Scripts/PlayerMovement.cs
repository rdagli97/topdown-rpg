using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private CharacterController characterController;
    private IA_PlayerInput playerInput;

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
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        Vector3 _moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        characterController.Move(_moveDirection * moveSpeed * Time.deltaTime);
    }
}
