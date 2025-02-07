using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private IA_PlayerInput playerInput;
    private Vector2 mousePosition;
    private Vector3 aimTarget;

    private void Awake()
    {
        playerInput = new IA_PlayerInput();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Aim.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Aim.canceled -= ctx => mousePosition = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            aimTarget = hit.point;
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.forward = direction;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aimTarget, .2f);
    }
}
