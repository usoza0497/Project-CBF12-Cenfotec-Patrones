using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaKamikaseAttackController : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint1;
    public float attackRange = 0.5f;
    private float lastAttackTime = 0f;
    public float attackCooldown = 2f;

    public LayerMask playerLayer;
    private Transform player;
    private PlayerController playerController;
    public float detectionRange = 2f;
    private Collider2D myCollider;

    private Enemy enemy; // Reference to the enemy

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        myCollider = GetComponent<Collider2D>();

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
        else
        {
            animator.SetTrigger("Run");
        }
    }

    public void Attack1()
    {
        PerformAttack(attackPoint1, attackRange);
    }

    private void PerformAttack(Transform attackPoint, float range)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);

        foreach (Collider2D item in hitPlayer)
        {
            // Verificar si el jugador sigue en rango
            for (int i = 0; i < 4; i++)
            {
                if (Vector2.Distance(item.transform.position, attackPoint.position) <= range)
                {
                    GameManager.instance.LoseHealth();
                    playerController.GetHurt();
                }
            }

            animator.SetTrigger("Death");
            attackRange = 0;

            if (myCollider != null)
            {
                myCollider.enabled = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
    }
}
