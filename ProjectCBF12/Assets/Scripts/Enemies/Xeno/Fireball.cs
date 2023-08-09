using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    //SerializedField variables
    [SerializeField] float projectileVelocity = 20f;

    //Private variables
    private Rigidbody2D myRigidbody;
    private GameObject enemy;
    private float bulletSpeed;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Enemy");
        bulletSpeed = projectileVelocity;
    }

    // Update is called once per frame
    public void Update()
    {
        myRigidbody.velocity = new Vector2(bulletSpeed, 0f);
    }

    //OnCollisionEnter2D is called when the bullet collides with something
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}