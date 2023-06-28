using ReflectionFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    public static PlayerController instance;
    public string areaTransitionName;
    public Transform FirePoint;
    public GameObject projectile;    
    
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

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, FirePoint.position, Quaternion.identity);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);;
        }
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("isWalking", true);
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        } else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }
}