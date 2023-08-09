using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Assets.Scripts.UI.Level_Loading;
public class PlayerController : MonoBehaviour
{
    //SerializedField variables
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0f, 20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    //Private variables
    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private CapsuleCollider2D myBodyCollider;
    private BoxCollider2D myFeetCollider;
    private bool isAlive = true;   

    //Public variables
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioClip fireSound;

    public bool IsAlive { get => isAlive; set => isAlive = value; }
    
    // Start is called before the first frame update
    public void Start()
    {   
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponentInChildren<BoxCollider2D>();
        GameManager.instance.ResetGame(); 
    }

    // Update is called once per frame
    public void Update()
    {
        if (!isAlive) { return; }

        Walk();
        FlipSprite();
        //GetHurt();
        Die();
        Bouncing();
    }

    //OnMove is called when the player moves
    public void OnMove(InputValue value)
    {
        if (!isAlive) { return; }

        moveInput = value.Get<Vector2>();
    }

    //OnJump is called when the player jumps
    public void OnJump(InputValue value)
    {
        if (!isAlive) { return; }

        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")) && !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))) { return; }
        
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            AudioManager.instance.PlaySound(jumpSound);
        }
    }

    //OnFire is called when the player fires a bullet
    public void OnFire(InputValue value)
    {
        if (!isAlive) { return; }

        if (PauseMenu.isPaused) { return; }
        
        if (value.isPressed)
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
            AudioManager.instance.PlaySound(fireSound);
        }    
    }

    //Walk controls the player's movement
    public void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    //FlipSprite flips the player's sprite when they change direction
    public void FlipSprite()
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!isAlive) { return; }

        if (other.gameObject.CompareTag("Hazards")) {
            myRigidbody.velocity = deathKick;
            GameManager.instance.LoseHealth();
        }
    }

    //Die kills the player when they touch a hazard
    public void Die()
    {
        if (GameManager.instance.GetTotalHealth == 0)
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;

            GameManager.instance.ResetGame();
            LevelLoader.FadeToLevel(SceneManager.GetActiveScene().name);
        }
    }

    public void Bouncing()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")))
        {
            AudioManager.instance.PlaySound(jumpSound);
        }
    }

    //GetHurt is called when the player gets hurt by an enemy or hazard
    public void GetHurt()
    {
        if (!isAlive) { return; }
        myAnimator.SetTrigger("Hurt");
    }
}