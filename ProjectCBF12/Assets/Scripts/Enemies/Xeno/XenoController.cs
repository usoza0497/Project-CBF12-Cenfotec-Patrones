using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoController : MonoBehaviour
{
    private Transform player;
    private bool isFlipped = false;
    [SerializeField] GameObject fireball;
    [SerializeField] Transform mouth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        FlipSprite();
    }

    //FlipSprite flips the enemy's sprite when they change direction
    public void FlipSprite()
    {
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

    public void Fire()
    {
        if(!isFlipped) { 
        Instantiate(fireball, mouth.position, transform.rotation);
        }
        else
        {
            Instantiate(fireball, mouth.position, Quaternion.Euler(0, 180, 0));
        }
    }
}