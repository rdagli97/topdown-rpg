using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject healPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(coinPrefab, collision.gameObject.transform.position, Quaternion.identity);

        int _randomInt = GenerateRandomInt0to100();

        if (_randomInt <= 33)
        {
            Transform _goTransform = collision.gameObject.transform;
            Instantiate(healPrefab, _goTransform.position + new Vector3(0.5f , 0, 0), Quaternion.identity);
        }
    }

    private int GenerateRandomInt0to100()
    {
        int _randomInt = Random.Range(0, 100);

        return _randomInt;
    }
}
