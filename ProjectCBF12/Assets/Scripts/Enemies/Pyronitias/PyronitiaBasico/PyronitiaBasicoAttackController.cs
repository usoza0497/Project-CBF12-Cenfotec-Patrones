using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaBasicoAttackController : MonoBehaviour
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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        float distanceWithTarget = Vector2.Distance(player.position, attackPoint1.position);

        if (distanceWithTarget <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("Attack1");
            lastAttackTime = Time.time;
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
