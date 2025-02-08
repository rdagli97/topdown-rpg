using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] spawnAreas;
    [SerializeField] private float spawnRate;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    private Vector3 GetRandomPosition()
    {
        if (spawnAreas == null)
        {
            Debug.Log("Spawn areas is empty");
            return Vector3.zero;
        }

        GameObject _randomSpawnArea = PickRandomGameObject(spawnAreas);

        BoxCollider boxCollider = _randomSpawnArea.GetComponent<BoxCollider>();

        float randomX = Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2);
        float randomZ = Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2);

        Vector3 _spawnPosition = _randomSpawnArea.transform.position + new Vector3(randomX, 0, randomZ);

        return _spawnPosition;
    }

    private void SpawnEnemy()
    {
        Vector3 _spawnPos = GetRandomPosition();
        Instantiate(enemyPrefab, _spawnPos, Quaternion.identity);
    }

    private GameObject PickRandomGameObject(GameObject[] _list)
    {
        int _randomInt = Random.Range(0, _list.Length);

        return _list[_randomInt];
    }
}
