using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {   
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (GameController.enemySpawned < 3)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        //float randomSpawnX = UnityEngine.Random.Range(-6, 13);
        //float randomSpawnZ = UnityEngine.Random.Range(-0.5f, 18);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        GameController.enemySpawned++;
    }
}
