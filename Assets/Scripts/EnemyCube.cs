using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 targetPosition;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            Debug.Log("Enemy close enough");
            Destroy(gameObject);
        }
    }
}
