using ReflectionFactory;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private Rigidbody2D myRB;
    public float speed;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        myRB.velocity = new Vector2(+speed, 0);
        Destroy(gameObject, 5f);
    }
}