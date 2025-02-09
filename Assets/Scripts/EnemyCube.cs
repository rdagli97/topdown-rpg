using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Vector3 targetPosition;
    private Transform player;
    private PlayerController playerController;


    private void Awake()
    {
        GameObject _playerTransform = GameObject.FindGameObjectWithTag("Player");
        player = _playerTransform.transform;
        playerController = _playerTransform.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (player == null)
            return;

        targetPosition = player.position;

        float _fixedY = transform.position.y;
        Vector3 _targetWithFixedY = new Vector3(targetPosition.x, _fixedY, targetPosition.z);

        transform.position = Vector3.MoveTowards(transform.position, _targetWithFixedY, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetWithFixedY) < 1f)
        {
            Destroy(gameObject);
            playerController.TakeDamage(damage);
        }
    }
}
