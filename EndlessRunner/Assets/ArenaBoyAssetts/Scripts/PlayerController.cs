﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Gravity Variables
    public float fallMultiplier = 2.5f;
   





    //Jumping Attributes
    public float maxJumpTime;
    public float currentGravity;
   

    //lerperators
    float lerpTime = 1f;
    float currentLerpTime;



    //playerAttributes
    public float jumpVelocity;
    public float playerSpeed;
    public float maxSpeed;
    public float slideSpeed;




    public float lastDistance;
    public float smoothTime;

    // GroundCheckers
    bool grounded;
    bool wasGrounded = false;
   public Transform groundCheck;
   public  Transform ceilingCheck;
    float groundRadius = 0.1f;
    float ceilingRadius = 0.1f;

    // Components
    private Collider2D playerCollider;
    private Animator myAnimator;
    public Rigidbody2D rb;

    public bool isDead;

    [SerializeField] LayerMask whatIsGround;



    //test
    public float lastTimeGrounded;


    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        maxSpeed = playerSpeed;
        maxJumpTime = 1;
        
      



    }

    public void Update()
    {
        if (!isDead) {
            rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            // BetterJump();

            AntiGravJump();
            Slide();
            AnimationControll();
        }else if (isDead)
        {
            rb.velocity = new Vector2(0,0);
            rb.gravityScale = 0;
            myAnimator.SetBool("isDead", true);

        }
        
    }

    public void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
      //  Debug.Log(grounded);
    }



    public void AntiGravJump()
    {
            //Innitial jumpVelocity 
            if (Input.GetKeyDown(KeyCode.W)&&rb.velocity.y==0)
            {
                currentLerpTime = 0;
                rb.velocity = new Vector2(playerSpeed, 1 * jumpVelocity);

            }


            // Gravity modifiers to float a little longer
            if (Input.GetKey(KeyCode.W))
            {

                if (currentLerpTime < maxJumpTime)
                {
                    currentLerpTime += Time.deltaTime;

                }
                else
                {
                    currentLerpTime = maxJumpTime;
                }

                // Lerp vom 0 -1 Gravity 
                float t = currentLerpTime / maxJumpTime;
                t = Mathf.Sin(t * Mathf.PI * 0.5f);


                currentGravity = Mathf.Lerp(0, 3, t);
                rb.gravityScale = currentGravity;

            }

            // Gravity increase for better fall

            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.gravityScale = fallMultiplier;

            }
        
    }



    public void AnimationControll()
    {
        //Animation Setters
        if (rb.velocity.y > 0)
        {
            myAnimator.SetBool("isJumping", true);
        }
        if (rb.velocity.y < -1 )
        {

        }
        if (rb.velocity.y == 0 && myAnimator.GetBool("Sliding") == false)
        {
            myAnimator.SetBool("isJumping", false);
            playerSpeed+=0.001f;
        }
    }


    public void Slide()
    {
        if (Input.GetKey(KeyCode.S) && myAnimator.GetBool("isJumping") == false)
        {
            //smoothTime = Mathf.Sqrt(smoothTime * Mathf.PI * 0.5f);
            //playerSpeed = Mathf.Lerp(slideSpeed,maxSpeed, smoothTime * Time.deltaTime);
            myAnimator.SetBool("Sliding", true);
        }
        else
        {
            //playerSpeed = Mathf.Lerp(playerSpeed, maxSpeed, smoothTime * Time.deltaTime);
            myAnimator.SetBool("Sliding", false);
        }

    }
    public void PlayDeath()
    {
        // hier kommen die todesanimationen rein!
    }
   
}
    

