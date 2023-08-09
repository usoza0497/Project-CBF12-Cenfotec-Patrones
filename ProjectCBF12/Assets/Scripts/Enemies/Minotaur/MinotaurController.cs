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
    private Transform attackController;

    public Slider healthBar;
    public float attackRadio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();
        boss = GetComponent<Minotaur>();
        boss.SetName();
        boss.SetMeleeAttacks();
        boss.SetRangeAttacks();
        attackController = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        FlipSprite();
        UpdateHealthBar();
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (!boss.IsAlive()) return;

        if (other.gameObject.CompareTag("Bullet")) {
            boss.ReceiveDamage(10);
        }
    }

    private void UpdateHealthBar() {
        healthBar.value = boss.BossHealth / 100;
    }

    private void Die() {
        if (!boss.IsAlive() && isDeathTriggered == false) {
            myAnimator.SetTrigger("Death");
            isDeathTriggered = true;
            bossDoor.SetActive(true);
        }
    }
}
