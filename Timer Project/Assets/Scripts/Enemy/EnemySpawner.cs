using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player; 
    public GameObject enemy;

    [Header("Spawn Timer")]
    [SerializeField] float spawnTimer = 0f;
    [SerializeField] float spawnInterval = 15f;

    [Header("Spawn Interval Increase")]
    [SerializeField] float intervalTimer = 0f;
    [SerializeField] float increaseInterval = 60f;

    [Header("Enemy Location")]
    [SerializeField] GameObject[] enemySpawners = new GameObject[5];
    private int randomSpawner;
    private GameObject chosenSpawner;

    void Start()
    {
        enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // called once per frame 
    void Update()
    {
        if (player  != null)
        {
            SpawnEnemy();
        }
    }

    // spawns enemy object
    void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;
        intervalTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            Debug.Log("enemy spawned");

            spawnTimer = 0;

            randomSpawner = Random.Range(0, enemySpawners.Length);
            chosenSpawner = enemySpawners[randomSpawner];
            
            Instantiate(enemy, chosenSpawner.transform.position, transform.rotation);
        }

        if (intervalTimer >= increaseInterval)
        {
            intervalTimer = 0;
            spawnInterval = 10f;
        }
    }
}
