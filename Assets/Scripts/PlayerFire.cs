using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private IA_PlayerInput playerInput;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform firePoint;

    [Header("Fire")]
    [SerializeField] private float fireRate;
    private float fireCooldown;

    private void Update()
    {
        fireCooldown -= Time.deltaTime;
        Debug.Log(CanFire());
    }

    private void OnEnable()
    {
        playerInput = new IA_PlayerInput();
        playerInput.Enable();
        playerInput.Player.Fire.started += ctx => InvokeRepeating(nameof(Fire), 0, .001f);
        playerInput.Player.Fire.performed += ctx => Fire();

        playerInput.Player.Fire.canceled += ctx => CancelInvoke();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Fire()
    {
        if (!CanFire()) return;

        fireCooldown = fireRate;
        GameObject _newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        _newBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(_newBullet, 10f);
    }

    private bool CanFire()
    {
        if (fireCooldown <= 0)
            return true;

        return false;
    }
}
