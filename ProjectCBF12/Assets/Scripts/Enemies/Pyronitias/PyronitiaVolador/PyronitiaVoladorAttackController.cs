using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaVoladorAttackController : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint1;
    private float attackRange = 0.5f;
    private float lastAttackTime = 0f;
    private float attackCooldown = 1f;

    public LayerMask playerLayer;
    private Transform player;
    private PlayerController playerController;
    private float detectionRange = 0.7f;

    private Enemy enemy;
    public PyronitiaVoladorController pyronitiaVoladorController;
    private bool isChasing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        enemy = GetComponent<Enemy>();
        pyronitiaVoladorController = GetComponent<PyronitiaVoladorController>();
    }

    private void Update()
    {
        float distanceWithTarget = Vector2.Distance(player.position, attackPoint1.position);

        if (distanceWithTarget <= detectionRange)
        {
            // Detener el chase solo si no se estaba persiguiendo anteriormente
            if (!isChasing)
            {
                pyronitiaVoladorController.StopChase();
                isChasing = true;
            }

            // Realizar el ataque cuerpo a cuerpo
            enemy.SetMeleeAttacks();

            string attackUsed = enemy.MeleeAttack();
            if (!string.IsNullOrEmpty(attackUsed) && Time.time - lastAttackTime >= attackCooldown)
            {
                animator.SetTrigger(attackUsed);
                lastAttackTime = Time.time;
            }
        }
        else if (distanceWithTarget <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            // Realizar el ataque cuerpo a cuerpo
            enemy.SetMeleeAttacks();

            string attackUsed = enemy.MeleeAttack();
            if (!string.IsNullOrEmpty(attackUsed))
            {
                animator.SetTrigger(attackUsed);
                lastAttackTime = Time.time;
            }
        }
        else
        {
            if (isChasing)
            {
                // Reanudar el chase solo si estaba persiguiendo anteriormente
                pyronitiaVoladorController.ResumeChase();
                isChasing = false;
            }

            animator.SetTrigger("Fly");
        }
    }

    private void Attack1()
    {
        PerformAttack(attackPoint1, attackRange);
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
        if (attackPoint1 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
    }
}
