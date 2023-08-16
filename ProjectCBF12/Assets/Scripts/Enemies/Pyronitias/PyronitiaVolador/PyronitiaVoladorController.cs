using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyronitiaVoladorController : MonoBehaviour
{
    PyronitiaVolador pyronitia;
    private Animator myAnimator;
    private Transform player;
    private bool isFlipped = false;
    private bool isDeathTriggered = false;
    private float speed = 4f;

    public Transform attackController;
    public float attackRadio;

    public PyronitiaVoladorController pyronitiaVoladorController;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();
        pyronitia = GetComponent<PyronitiaVolador>();
        pyronitia.SetName();
        pyronitia.SetRangeAttacks();
    }

    void Update()
    {
        Chase();
        FlipSprite();
        Die();
    }
    private void FlipSprite()
    {
        if (!pyronitia.IsAlive()) return;

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
        if (!pyronitia.IsAlive()) return;

        if (other.gameObject.CompareTag("Bullet"))
        {
            pyronitia.ReceiveDamage(10);
        }
    }

    private void Die()
    {
        if (!pyronitia.IsAlive() && isDeathTriggered == false)
        {
            myAnimator.SetTrigger("Death");
            isDeathTriggered = true;
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void StopChase()
    {
        speed = 0f;
    }

    public void ResumeChase()
    {
        speed = 4f;
    }
}