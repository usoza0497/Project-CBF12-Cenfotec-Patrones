using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PyronitiaAvanzadoController : MonoBehaviour
{
    private PyronitiaAvanzado pyronitia;
    private Animator myAnimator;
    private Transform player;
    private bool isFlipped = false;
    private bool isDeathTriggered = false;

    public Transform attackController;
    public Transform attackController2;
    public float attackRadio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();
        pyronitia = GetComponent<PyronitiaAvanzado>();
        pyronitia.SetName();
        pyronitia.SetMeleeAttacks();
    }

    private void Update()
    {
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadio);
        Gizmos.DrawWireSphere(attackController2.position, attackRadio);
    }

}
