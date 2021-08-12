using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //move&jump speed var
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;
    public float speedIncreasePoint;
    private float speedIncreasePointStore;
    private float speedPointCount;
    private float speedPointCountStore;
    public float jumpForce;
    //set jump air time
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJump;
    private bool doubleJump;
    //rigid body var
    private Rigidbody2D myRB;
    //var for checking if player is on ground
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    //uses box collider
    //private Collider2D myCollider;
    //
    private Animator myAnimator;
    public GameManager gameMan;

    //audio
    public AudioSource jumpsfx;
    public AudioSource deathsfx;
    
    // Start is called before the first frame update
    void Start()
    {
        //player able to react with myRB and other vars when script runs
        myRB = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedPointCount = speedIncreasePoint;

        moveSpeedStore = moveSpeed;
        speedPointCountStore = speedPointCount;
        speedIncreasePointStore = speedIncreasePoint; 
        stoppedJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //bool checks if character is touching any layers
        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x>speedPointCount){
            speedPointCount+= speedIncreasePoint;
            speedIncreasePoint = speedIncreasePoint*speedMultiplier;
            moveSpeed = moveSpeed*speedMultiplier;
        }

        //  | |  below player movement vectors increased when in motion
        //  v v
        myRB.velocity=new Vector2(moveSpeed , myRB.velocity.y);

        //check if char should jump (when pressing space of mouse left click)
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
           if(grounded){
                //jump if grounded
                myRB.velocity=new Vector2(myRB.velocity.x, jumpForce);
                stoppedJump = false;
                jumpsfx.Play(); 
           }
           if(!grounded && doubleJump){
               myRB.velocity=new Vector2(myRB.velocity.x, jumpForce);
               jumpTimeCounter = jumpTime;
               stoppedJump = false;
               doubleJump = false;
               jumpsfx.Play(); 
           }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !stoppedJump){
            if(jumpTimeCounter>0){
                myRB.velocity=new Vector2(myRB.velocity.x, jumpForce);
                jumpTimeCounter-=Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)){
            jumpTimeCounter = 0;
            stoppedJump = true;
        }
        if (grounded){
            jumpTimeCounter = jumpTime;
            doubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRB.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "killBox"){
            gameMan.restartGame();
            moveSpeed = moveSpeedStore;
            speedPointCount = speedPointCountStore;
            speedIncreasePoint = speedIncreasePointStore;
            deathsfx.Play();
        }
    }
}
