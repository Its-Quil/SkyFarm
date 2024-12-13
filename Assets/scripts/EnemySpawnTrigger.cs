using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public bool respawnEnabled = true; // Checkbox to enable/disable respawn
    public float respawnTime = 10f; // Time in seconds for respawn
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform[] patrolPoints; // Array of patrol points

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && respawnEnabled)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                SpawnEnemyAtPoint(spawnPoint.position, respawnTime);
            }
        }
    }

    public void RespawnEnemy(GameObject enemy)
    {
        if (respawnEnabled)
        {
            Transform respawnPoint = GetRespawnPoint();
            if (respawnPoint != null)
            {
                StartCoroutine(RespawnEnemyCoroutine(respawnPoint.position, respawnTime));
            }
        }
    }

    private IEnumerator RespawnEnemyCoroutine(Vector3 respawnPosition, float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        // Instantiate the enemy at the specified respawn position
        GameObject newEnemy = Instantiate(enemyPrefab, respawnPosition, Quaternion.identity);

        // Assign patrol points to the new enemy
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.patrolPoints = patrolPoints;
        }
    }

    private Transform GetRespawnPoint()
    {
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomIndex];
        }
        return null;
    }

    private void SpawnEnemyAtPoint(Vector3 spawnPosition, float respawnTime)
    {
        StartCoroutine(RespawnEnemyCoroutine(spawnPosition, respawnTime));
    }
}
