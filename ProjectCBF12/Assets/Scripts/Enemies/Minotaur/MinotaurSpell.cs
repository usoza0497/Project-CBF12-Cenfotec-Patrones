using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurSpell : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Transform boxPosition;
    [SerializeField] private float attackDuration = 0.5f;
    private bool isHit = false;

    private void Start()
    {
        Destroy(gameObject, attackDuration);
        isHit = false;
    }

    public void Hit()
    {
        if(isHit) return;

        isHit = true;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxPosition.position, boxSize, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                GameManager.instance.LoseHealth();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxPosition.position, boxSize);
    }
}
