using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaAvanzadoAttackController : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint1;
    public float attackRange = 0.5f;
    public float attackCooldown = 4f;
    private float lastAttackTime = 0f;

    public Transform attackPoint2;
    public float attackRange2 = 0.7f;
    public float attackCooldown2 = 6f;
    private float lastAttackTime2 = 0f;

    public LayerMask playerLayer;
    private Transform player;
    private PlayerController playerController;

    public float detectionRange = 2f;

    private Enemy enemy; // Reference to the enemy

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();

        // Get the reference to the enemy
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        float distanceWithTarget = Vector2.Distance(player.position, attackPoint1.position);

        if (distanceWithTarget <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            // Use the SetMeleeAttacks method to update available attacks
            enemy.SetMeleeAttacks();

            // Perform melee attack
            string attackUsed = enemy.MeleeAttack();
            if (!string.IsNullOrEmpty(attackUsed))
            {
                animator.SetTrigger(attackUsed);
                lastAttackTime = Time.time;
            }
        }
        else if (distanceWithTarget <= attackRange && Time.time - lastAttackTime2 >= attackCooldown2)
        {
            // Use the SetMeleeAttacks method to update available attacks
            enemy.SetMeleeAttacks();

            // Perform melee attack
            string attackUsed = enemy.MeleeAttack();
            if (!string.IsNullOrEmpty(attackUsed))
            {
                animator.SetTrigger(attackUsed);
                lastAttackTime2 = Time.time;
            }
        }
        else if (distanceWithTarget <= detectionRange)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }

    private void Attack1()
    {
        PerformAttack(attackPoint1, attackRange);
    }

    private void Attack2()
    {
        PerformAttack(attackPoint2, attackRange2);
    }

    private void PerformAttack(Transform attackPoint, float range)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);

        foreach (Collider2D item in hitPlayer)
        {
            // Verificar si el jugador sigue en rango
            if (Vector2.Distance(item.transform.position, attackPoint.position) <= range)
            {
                GameManager.instance.LoseHealth();
                playerController.GetHurt();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null || attackPoint2 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
    }
}
