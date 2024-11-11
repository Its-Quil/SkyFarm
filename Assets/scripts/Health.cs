using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // Property to get the current health
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(gameObject.name + " health initialized to " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage, current health: " + currentHealth);

        // Play hurt animation
        // animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died");

        // Play death animation
        // animator.SetTrigger("Die");

        if (gameObject.CompareTag("Enemy"))
        {
            // Notify the EnemyManager to respawn this enemy
            EnemyManager.instance.RespawnEnemy(5f); // Adjust the respawn timer as needed
            Destroy(gameObject); // Destroy the enemy immediately
        }

        if (gameObject.CompareTag("player"))
        {
            // Handle player death
            GameManager.instance.GameOver();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        Debug.Log(gameObject.name + " health reset to " + currentHealth);
    }
}
public class ExampleUsage : MonoBehaviour
{
    public Health healthComponent;

    void Update()
    {
        if (healthComponent != null)
        {
            Debug.Log("Current Health: " + healthComponent.CurrentHealth);
        }
    }
}
