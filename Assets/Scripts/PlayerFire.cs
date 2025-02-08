using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private IA_PlayerInput playerInput;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform firePoint;

    private void OnEnable()
    {
        playerInput = new IA_PlayerInput();
        playerInput.Enable();
        playerInput.Player.Fire.performed += ctx => Fire();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Fire()
    {
        Debug.Log("Fire button pressed");
        GameObject _newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        _newBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(_newBullet, 10f);
    }
}
