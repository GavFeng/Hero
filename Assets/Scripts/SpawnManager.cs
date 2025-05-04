using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    [SerializeField] private float spawnRangeX = 8f;
    [SerializeField] private float spawnRangeY = 4f;
    [SerializeField] private float spawnRangeZ = 8f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies(maxEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (currentEnemies < maxEnemies)
        {
            int toSpawn = maxEnemies - currentEnemies;
            SpawnEnemies(toSpawn);
        }
    }

    //Spawns animals randomly
    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameManager.Instance.UpdateEnemyCount(1);
            Vector3 spawnPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY),
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
            enemy.tag = "Enemy"; 
        }
    }
}
