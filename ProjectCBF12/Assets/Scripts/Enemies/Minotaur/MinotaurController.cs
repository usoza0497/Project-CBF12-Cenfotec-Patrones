using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI.Level_Loading;

public class MinotaurController : MonoBehaviour
{
    private Minotaur boss;
    private Animator myAnimator;
    private Transform player;
    private bool isFlipped = false;
    private bool isDeathTriggered = false;

    public GameObject bossDoor;
    public Transform attackController;
    public Slider healthBar;
    public float attackRadio;
    public AudioClip breathSound;
    public AudioClip attackSound;
    public AudioClip deathSound;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();
        boss = GetComponent<Minotaur>();
        boss.SetName();
        boss.SetMeleeAttacks();
        boss.SetRangeAttacks();
    }

    // Update is called once per frame
    private void Update()
    {
        FlipSprite();
        GameManager.instance.UpdateBossHealthBar(boss.BossHealth / 100);
        Die();
    }

    //FlipSprite flips the enemy's sprite when they change direction
    public void FlipSprite()
    {
        if (!boss.IsAlive()) return;

        if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = new Vector2(-1f, 1f);
            isFlipped = true;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = new Vector2(1f, 1f);
            isFlipped = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!boss.IsAlive()) return;

        if (other.gameObject.CompareTag("Bullet")) {
            boss.ReceiveDamage(5);
        }
    }

    private void Die()
    {
        if (!boss.IsAlive() && isDeathTriggered == false)
        {
            myAnimator.SetTrigger("Death");
            isDeathTriggered = true;
            bossDoor.SetActive(true);
        }
    }

    public void Attack()
    {
        if (!boss.IsAlive()) return;

        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadio);

        foreach (Collider2D collision in objects)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.LoseHealth();
                player.GetComponent<PlayerController>().GetHurt();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadio);
    }

    public void PlayBreathSound()
    {
        AudioManager.instance.PlaySound(breathSound);
    }

    public void PlayAttackSound()
    {
        AudioManager.instance.PlaySound(attackSound);
    }

    public void PlayDeathSound()
    {
        AudioManager.instance.PlaySound(deathSound);
    }
}