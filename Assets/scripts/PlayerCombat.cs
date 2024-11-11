using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.5f; // Increased attack range
    public LayerMask enemyLayers; // Ensure this is set to the "Enemy" layer in the Inspector
    public int attackDamage = 20;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Left mouse button
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Play attack animation
        // animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
