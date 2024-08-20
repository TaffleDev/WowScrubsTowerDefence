using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemySpawner.StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
