using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Attributes

    //Interface 
    public Slider jumpSlider;
    public Slider comboSlider;
    public int comboCounter;
    public Text comboText;
   
    public ParticleSystemSlider particleEffect;


    // Jump Mechanic
    public int jumpLevel1;
    public int jumpLevel2;
    public int jumpLevel3;

    [SerializeField] float jumpPressure;
    [SerializeField] float minJumpPressure;
    [SerializeField] float maxJumpPressure;

    public float chargeAnzeige;


    // Unity References
    private Collider2D playerCollider;
    public Animator anim_character;
    public Animator myCanvasAnimator;
    public Rigidbody2D rb;
    public ParticleSystem perfectEffect;
    

    //Character Attributes
    public bool isDead;
    public float playerSpeed;
    public float maxSpeed;
    public float currentSpeed;





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponentInChildren<Collider2D>();
        anim_character = GetComponentInChildren<Animator>();
        myCanvasAnimator = FindObjectOfType<Canvas>().GetComponent<Animator>();
        particleEffect = FindObjectOfType<ParticleSystemSlider>();
        
        
    }


    void Start()
    {
        SetStartValues();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        Jump();
        animationTest();
        moveCharackterRight();
        UpdateHealthbar();
        CharacterStateChecker();

    }

    void animationTest()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {

            anim_character.SetTrigger("Jump1");

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {

        }
        if (Input.GetKeyDown(KeyCode.F3))
        {

        }
    }

    void moveCharackterRight()
    {
        this.transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
    }


    public void Jump()
    {
      
        //Jump Charge
        if (Input.GetKey(KeyCode.W) && rb.velocity.y == 0)
        {
           
            if (jumpPressure < maxJumpPressure)
            {

                // sollte exponentiel wachsen

                jumpPressure += Time.deltaTime * 10f;
                //füllt die Charge anzeige auf!
                chargeAnzeige = jumpPressure / maxJumpPressure;

            }
            else
            {
                jumpPressure = maxJumpPressure;

            }

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
               // anim_character.SetBool("isCharging", false);
                //actual jump
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJumpPressure;
                    anim_character.SetBool("isGrounded", false);
                    // vielleicht einfach so für die 3 Stufen? 
                    if (jumpPressure >= 8)
                    {
                        anim_character.SetTrigger("Jump3");
                    }
                    else if (jumpPressure >= 4)
                    {
                       
                        anim_character.SetTrigger("Jump2");
                    }
                    else if (jumpPressure > 0)
                    {
                       
                        anim_character.SetTrigger("Jump1");
                    }                    


                    // Hier ist die Belohnungsanzeige für den perfekten Sprung---------------------------------------------------------------------------------------------

                    if (chargeAnzeige >= 0.2f && chargeAnzeige <= 0.3f)
                    {
                        myCanvasAnimator.SetTrigger("Trigger_Perfect");
                        particleEffect.ParticleIndex = 1;
                        perfectEffect.Play();
                    }
                    if (chargeAnzeige <= 0.6f && chargeAnzeige >= 0.5f)
                    {
                        myCanvasAnimator.SetTrigger("Trigger_Perfect");
                        particleEffect.ParticleIndex = 2;
                        perfectEffect.Play();
                    }
                    if (chargeAnzeige >= 0.8f && chargeAnzeige <= 0.9f)
                    {
                        particleEffect.ParticleIndex = 3;
                        myCanvasAnimator.SetTrigger("Trigger_Perfect");
                        perfectEffect.Play();
                    }

                    // wenn kein Perfect dann nur gut
                    if (!(chargeAnzeige >= 0.2f && chargeAnzeige <= 0.3f || chargeAnzeige <= 0.6f && chargeAnzeige >= 0.5f || chargeAnzeige >= 0.8f && chargeAnzeige <= 0.9f))
                    {
                        myCanvasAnimator.SetTrigger("Trigger_Good");
                    }
                    // wenn irgend ein perfect dann playerspeed++   ( am besten hier playerspeed erhöhen für kurze zeit aber significant)  
                    if ((chargeAnzeige >= 0.2f && chargeAnzeige <= 0.3f || chargeAnzeige <= 0.6f && chargeAnzeige >= 0.5f || chargeAnzeige >= 0.8f && chargeAnzeige <= 0.9f))
                    {
                        playerSpeed++;
                        comboCounter++;

                    }

                    jumpPressure = 0f;
                    chargeAnzeige = 0f;


                }
            }

        }
    }

    public void SetStartValues()
    {
        //rb.gravityScale = 1;
        //maxSpeed = playerSpeed;
        //maxJumpTime = 1;
        //transform.position = spawnPosition;
       // anim_character.SetBool("isDead", false);
        playerSpeed = 1;
        //new Jump
        jumpPressure = 0f;
        minJumpPressure = 0.0f;
        maxJumpPressure = 12.0f;
        comboCounter = 0;

    }

    public void UpdateHealthbar()
    {
        jumpSlider.value = chargeAnzeige;
        if (Input.GetKeyUp(KeyCode.W))
        {
            jumpSlider.value = 0;
        }
    }

    public void CharacterStateChecker()
    {
        if (rb.velocity.y == 0 && anim_character.GetBool("isFalling") == true)
        {
            anim_character.SetBool("isGrounded", true);
        }
        if (rb.velocity.y < 0)
        {
            anim_character.SetBool("isFalling", true);
        }
        else
        {
            anim_character.SetBool("isFalling", false);
        }
    }
}
