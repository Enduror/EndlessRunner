using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //// Gravity Variables
    //public float fallMultiplier = 4f;






    ////Jumping Attributes
    //public float maxJumpTime;
    //public float currentGravity;


    ////lerperators
    //float lerpTime = 1f;
    //float currentLerpTime;



    ////playerAttributes
    //public float jumpVelocity;
    public float playerSpeed;
    //public float maxSpeed;
    //public float slideSpeed;

    //Vector3 spawnPosition;


    //public float lastDistance;
    //public float smoothTime;

    // GroundCheckers
    bool grounded;
    bool wasGrounded = false;
    public Transform groundCheck;
    public Transform ceilingCheck;
    float groundRadius = 0.1f;
    float ceilingRadius = 0.1f;
    

    // Components
    private Collider2D playerCollider;
    public Animator myAnimator;
    public Rigidbody2D rb;

    public bool isDead;

    [SerializeField] LayerMask whatIsGround;
    
    //test
    public float lastTimeGrounded;
    public float chargeAnzeige;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        //spawnPosition = transform.position;
    }

    private void Start()
    {
        SetStartValues();
    }

    public void SetStartValues()
    {
        //rb.gravityScale = 1;
        //maxSpeed = playerSpeed;
        //maxJumpTime = 1;
        //transform.position = spawnPosition;
        myAnimator.SetBool("isDead", false);

        //new Jump
        jumpPressure = 0f;
        minJumpPressure = 0.0f;
        maxJumpPressure = 12.0f;
     
    }

    public bool running = false;

    public void Update()
    {
        if(!isDead && myAnimator.GetBool("isSleeping") == false && running!= true)
        {
            StartCoroutine(MovePlayer());
            running = true;
        }
        if (!isDead && myAnimator.GetBool("isSleeping") == false)
        {
          
            // BetterJump();

            //AntiGravJump();
            //Slide();
            Jump();
            AnimationControll();


        }
        else if (isDead)
        {
            Die();
            this.enabled = false;
        }
        else if (myAnimator.GetBool("isSleeping") == true)
        {
            WakeUp();
        }

    }

    IEnumerator MovePlayer()
    {
        while (!isDead)
        {
            rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            playerSpeed++;
            //increase speed every second
            yield return new WaitForSeconds(1);                   
            //Vielleicht bei jedem Schritt ein Addforce? Dann sieht das bisschen mehr nach gas geben aus bzw dynamischer
            //rb.AddForce(Vector2.right*playerSpeed, ForceMode2D.Force);
        }       

    }

    [SerializeField] float jumpPressure;
    [SerializeField] float minJumpPressure;
    [SerializeField] float maxJumpPressure;

    public void Jump()
    {
        if (Input.GetKey(KeyCode.W) && rb.velocity.y == 0)
        {
            if(jumpPressure < maxJumpPressure)
            {
                jumpPressure += Time.deltaTime * 20f;               

                    chargeAnzeige = jumpPressure / maxJumpPressure;
                    Debug.Log(chargeAnzeige);
                
            }
            else
            {
                jumpPressure = maxJumpPressure;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
               
                chargeAnzeige = jumpPressure / maxJumpPressure;
                Debug.Log(chargeAnzeige);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                //actual jump
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJumpPressure;

                    rb.AddForce(Vector2.up * jumpPressure, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.right * jumpPressure, ForceMode2D.Impulse);

                    jumpPressure = 0f;
                }
            }
          
        }
    }

    public void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //  Debug.Log(grounded);
    }

    public void Die()
    {
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        //myAnimator.SetBool("isDead", true);
        //myAnimator.SetBool("isDead", false);
        Screenshot.captureScreenshot();
        Debug.Log("zwischen den beiden isDead das Foto machen und animation abwarten");
        ResetPlayer();
        GlobalData.Instance.button_restart.SetActive(true);
        GlobalData.Instance.button_quit.SetActive(true);
        running = false;
    }

    public void ResetPlayer()
    {
        SetStartValues();
        myAnimator.SetBool("isSleeping", true);
        GlobalData.Instance.tileManager.InstantiateGround();
    }

    //public void AntiGravJump()
    //{
    //    //Innitial jumpVelocity 
    //    if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0)
    //    {
    //        currentLerpTime = 0;
    //        rb.velocity = new Vector2(playerSpeed, 1 * jumpVelocity);

    //    }


    //    // Gravity modifiers to float a little longer
    //    if (Input.GetKey(KeyCode.W))
    //    {

    //        if (currentLerpTime < maxJumpTime)
    //        {
    //            currentLerpTime += Time.deltaTime;

    //        }
    //        else
    //        {
    //            currentLerpTime = maxJumpTime;
    //        }

    //        // Lerp vom 0 -1 Gravity 
    //        float t = currentLerpTime / maxJumpTime;
    //        t = Mathf.Sin(t * Mathf.PI * 0.5f);


    //        currentGravity = Mathf.Lerp(0, 3, t);
    //        rb.gravityScale = currentGravity;

    //    }

    //    // Gravity increase for better fall

    //    if (Input.GetKeyUp(KeyCode.W))
    //    {
    //        rb.gravityScale = fallMultiplier;

    //    }

    //}



    public void AnimationControll()
    {
        //Animation Setters
        if (rb.velocity.y > 0)
        {
            myAnimator.SetBool("isJumping", true);
        }
        if (rb.velocity.y < -1)
        {

        }
        if (rb.velocity.y == 0 && myAnimator.GetBool("Sliding") == false)
        {
            myAnimator.SetBool("isJumping", false);
            playerSpeed += 0.001f;
        }
    }


    //public void Slide()
    //{
    //    if (Input.GetKey(KeyCode.S) && myAnimator.GetBool("isJumping") == false)
    //    {
    //        //smoothTime = Mathf.Sqrt(smoothTime * Mathf.PI * 0.5f);
    //        //playerSpeed = Mathf.Lerp(slideSpeed,maxSpeed, smoothTime * Time.deltaTime);
    //        myAnimator.SetBool("Sliding", true);
    //    }
    //    else
    //    {
    //        //playerSpeed = Mathf.Lerp(playerSpeed, maxSpeed, smoothTime * Time.deltaTime);
    //        myAnimator.SetBool("Sliding", false);
    //    }

    //}
    public void PlayDeath()
    {
        // hier kommen die todesanimationen rein!
    }

    //--------------------ButtonsFürDenSpieler---------------///

    public void WakeUp()
    {
        if (Input.GetKey(KeyCode.D))
            {
            
            myAnimator.SetBool("isSleeping", false);
        }
    }

}
    

