using ReflectionFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator playerAnimator;
    public static PlayerController instance;
    public string areaTransitionName;
    public Transform FirePoint;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {   
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        playerAnimator.SetFloat("moveX", theRB.velocity.x);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
        }
    }
}