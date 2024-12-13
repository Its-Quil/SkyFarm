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

    public void SpawnEnemyAtPoint(Vector3 spawnPosition, float respawnTime)
    {
        StartCoroutine(SpawnEnemyCoroutine(spawnPosition, respawnTime));
    }

    private IEnumerator SpawnEnemyCoroutine(Vector3 spawnPosition, float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        // Instantiate the enemy at the specified spawn position
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Assign patrol points to the new enemy
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.patrolPoints = patrolPoints;
        }
    }
}
