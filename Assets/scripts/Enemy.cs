using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10f;
    public int attackDamage = 10;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    private int currentPatrolIndex;
    private bool isPatrolling;

    Transform target;
    NavMeshAgent agent;
    public Transform[] patrolPoints; // Keep this to receive patrol points from EnemyManager

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing from this GameObject. Please add a NavMeshAgent component.");
        }

        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            isPatrolling = true;
            currentPatrolIndex = 0;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }

        // Set the stopping distance to a value slightly larger than the attack range
        agent.stoppingDistance = 2f; // Adjust this value as needed
    }

    void Update()
    {
        if (agent == null || !agent.isOnNavMesh)
        {
            return; // Exit if NavMeshAgent is not attached or not on NavMesh
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            isPatrolling = false;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                if (Time.time >= nextAttackTime)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }

                // Face the target
                FaceTarget();
            }
        }
        else
        {
            if (!isPatrolling && patrolPoints != null && patrolPoints.Length > 0)
            {
                isPatrolling = true;
                agent.SetDestination(patrolPoints[currentPatrolIndex].position);
            }

            if (isPatrolling)
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Attack()
    {
        // Stop the enemy from moving
        agent.isStopped = true;
        Debug.Log("Enemy stopped to attack");

        // Play attack animation
        // animator.SetTrigger("Attack");

        // Damage the player
        if (target != null)
        {
            target.GetComponent<Health>().TakeDamage(attackDamage);
        }

        // Resume movement after a short delay
        StartCoroutine(ResumeMovementAfterAttack());
    }

    IEnumerator ResumeMovementAfterAttack()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed
        agent.isStopped = false;
        Debug.Log("Enemy resumed movement after attack");
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
