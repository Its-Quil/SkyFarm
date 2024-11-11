using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform[] patrolPoints; // Array of patrol points

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RespawnEnemy(float respawnTime)
    {
        StartCoroutine(RespawnEnemyCoroutine(respawnTime));
    }

    private IEnumerator RespawnEnemyCoroutine(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        // Instantiate the enemy at a random position or a predefined spawn point
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Assign patrol points to the new enemy
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.patrolPoints = patrolPoints;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Implement your logic to get a random spawn position
        // For example, you can use predefined spawn points or random positions within a certain area
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
