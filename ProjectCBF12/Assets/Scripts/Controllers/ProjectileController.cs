using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //SerializedField variables
    [SerializeField] float projectileVelocity = 20f;

    //Private variables
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBodyCollider;
    private GameObject player;
    private float bulletSpeed;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        bulletSpeed = player.transform.localScale.x * projectileVelocity;
    }

    // Update is called once per frame
    public void Update()
    {
        myRigidbody.velocity = new Vector2(bulletSpeed, 0f);
        if (player.GetComponent<PlayerController>().IsAlive == false)
        {
            Destroy(gameObject);
        }
    }

    //OnCollisionEnter2D is called when the bullet collides with something
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }


}