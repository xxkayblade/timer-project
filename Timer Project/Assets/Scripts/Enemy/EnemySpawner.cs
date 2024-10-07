using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player; 
    public GameObject enemy;
    public EnemyFollow enemyScript;

    [Header("Spawn Timer")]
    [SerializeField] float spawnTimer = 0f;
    [SerializeField] float spawnInterval = 15f;

    [Header("Random Spawn Timer")]
    [SerializeField] float randomSpawnTimer = 0f;
    [SerializeField] float[] spawnIntervals = new float[3];
    private int randomSpawnTime;
    [SerializeField] float chosenSpawnTime = 5f;

    [Header("Speed Increase")]
    [SerializeField] float speedTimer = 0f;
    [SerializeField] float speedInterval = 10f;

    [Header("Enemy Location")]
    [SerializeField] GameObject[] enemySpawners = new GameObject[8];
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
        randomSpawnTimer += Time.deltaTime; 
        speedTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            Debug.Log("enemy spawned");

            spawnTimer = 0;

            randomSpawner = Random.Range(0, enemySpawners.Length);
            chosenSpawner = enemySpawners[randomSpawner];
            Instantiate(enemy, chosenSpawner.transform.position, transform.rotation);
        }

        if (randomSpawnTimer >= chosenSpawnTime)
        {
            randomSpawnTimer = 0f;

            randomSpawner = Random.Range(0, enemySpawners.Length);
            chosenSpawner = enemySpawners[randomSpawner];
            Instantiate(enemy, chosenSpawner.transform.position, transform.rotation);

            randomSpawnTime = Random.Range(0, spawnIntervals.Length);
            chosenSpawnTime = spawnIntervals[randomSpawnTime];
        }

        if (speedTimer >= speedInterval)
        {
            speedTimer = 0;

            enemyScript = enemy.GetComponent<EnemyFollow>();
            enemyScript.enemySpeed++;
        }
    }
}
