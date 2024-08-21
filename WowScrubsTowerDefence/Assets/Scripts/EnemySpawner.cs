using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public SpawnManagerScriptableObject spawnManager;

    public GameObject[] enemyPrefab;
    public Transform[] pathWayPoints;
    public float spawnIntervals = 2f;

    public int maxPrefabsTospawn = 5;

    private bool isSpawning = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnIntervals);
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnEnemy));
    }

    public void SpawnEnemy()
    {
        if (spawnManager.numberOfPrefabsToCreate > maxPrefabsTospawn)
        {
            GameObject enemy = Instantiate(spawnManager.spawnPrefab, pathWayPoints[0].position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetPath(pathWayPoints);
        }
        
    }

}
