using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MapPlayerMovement : MonoBehaviour
{
    public MapPoint currentPoint;
    public float moveSpeed = 10f;
    private Animator myAnimator;
    private string levelSelected = "";

    public void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        movePlayer();
        playerHasSpeed();
        FlipSprite();
    }

    public void OnUp(InputValue value) {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f) {
            if (currentPoint.up != null) {
                SetNextPoint(currentPoint.up);
            } 
        } 
        
    }

    public void OnDown(InputValue value) {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f) {
            if (currentPoint.down != null) {
            SetNextPoint(currentPoint.down);
        }
        }
        
    }

    public void OnLeft(InputValue value) {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f) {
            if (currentPoint.left != null) {
            SetNextPoint(currentPoint.left);
        }
        }
        
    }

    public void OnRight(InputValue value) {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f) {
            if (currentPoint.right != null) {
            SetNextPoint(currentPoint.right);
        }
        }
        
    }

    public void OnEnter(InputValue value) {
        if (levelSelected != "")
        {
            LevelLoader.instance.FadeToLevel(levelSelected);
        } 
    }

    public void SetNextPoint(MapPoint nextPoint) {
        currentPoint = nextPoint;
    }

    public void movePlayer() {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);
    }

    public void playerHasSpeed() {
        if (transform.position != currentPoint.transform.position)
        {
            myAnimator.SetBool("isWalking", true);
        } else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    public void FlipSprite()
    {
        bool isMovingLeft = (transform.position.x - currentPoint.transform.position.x) > Mathf.Epsilon;
        if (isMovingLeft)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {            
        if (other.gameObject.tag == "Level Label")
        {
            levelSelected = other.gameObject.name;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {            
        if (other.gameObject.tag == "Level Label")
        {
            levelSelected = "";
        }
    }
    
}
