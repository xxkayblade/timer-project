using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    [Header("Spawn Timer")]
    [SerializeField] float spawnTimer = 0f;
    [SerializeField] float spawnInterval = 15f;

    [Header("Spawn Interval Increase")]
    [SerializeField] float intervalTimer = 0f;
    [SerializeField] float increaseInterval = 60f;

    // [Header("Enemy Location")]
    // GameObject enemyLocations[]; 

    // spawns enemy object
    void SpawnEnemy()
    {
        spawnTimer = Time.deltaTime;
        intervalTimer = Time.deltaTime;

        if (spawnTimer == spawnInterval)
        {
            spawnTimer = 0;
            Instantiate(enemy);
        }

        if (intervalTimer == increaseInterval)
        {
            intervalTimer = 0;
            spawnInterval = 10f;
        }
    }
}
