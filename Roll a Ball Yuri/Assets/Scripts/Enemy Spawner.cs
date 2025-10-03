using UnityEngine;

public class EnemySpawner : GameController
{
    [SerializeField]
    GameObject enemyPrefab;
    void Update()
    {
        if (enemySpawned < 3)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randomSpawnX = UnityEngine.Random.Range(-6, 13);
        float randomSpawnZ = UnityEngine.Random.Range(-0.5f, 18);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemySpawned++;
    }
}
