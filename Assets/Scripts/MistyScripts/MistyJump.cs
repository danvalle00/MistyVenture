using System;
using UnityEngine;
using UnityEngine.Android;

public class MistyJump : MonoBehaviour
{
    private Rigidbody2D mistyRigid;
    private MistyGroundCheck ground;
    private MistyAnimation animationScript;
    private Vector2 velocity;
    
    // Stats do Jump
    [SerializeField] private float jumpHeight = 7.0f;
    [SerializeField] private float jumpApexTime;
    [SerializeField] private float upGravityMultiplier = 1f;
    [SerializeField] private float downGravityMultiplier = 6f;
    
    // boberinhas de pulo
    [SerializeField] private float maxAirJump;
    [SerializeField] private bool variableJumpHeight;
    // jump cutoff é o downgravity pro variable jumpheight
    [SerializeField] private float jumpCutOff;
    [SerializeField] private float fallSpeedLimit;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float jumpBuffer = 0.15f;
    
    //  Calculos
    private float jumpSpeed;
    private float defaultGravity;
    private float gravityMultiplier = 1.0f;
    
    // estado atual
    private bool canJumpAgain;
    private bool desiredJump;
    private float jumpBufferCounter;
    private float coyoteTimeCounter;
    private bool pressingJump;
    public bool onGround;
    private bool currentlyJumping;


    private void Awake()
    {
        mistyRigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<MistyGroundCheck>();
        animationScript = GetComponent<MistyAnimation>();
        defaultGravity = 1f;
        
    }

    void onJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            desiredJump = true;
            pressingJump = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            pressingJump = false;
        }
    }

  
    void Update()
    {
        setPhysics();
        onJump();
        onGround = ground.GetOnGround();
        if (jumpBuffer > 0)
        {
            if (desiredJump)
            {
                jumpBufferCounter += Time.deltaTime; // jumpbuffer bagulhos
                if (jumpBufferCounter > jumpBuffer)
                {
                    desiredJump = false;
                    jumpBufferCounter = 0;
                }
            }
        }
        
        // coyote time bagulhos, significa que se o personagem n ta no chao e tbm n ta pulando
        // ai tem esse tempo ai pra apertar o butao de pulo
        if (!currentlyJumping && !onGround)
        {
            coyoteTimeCounter += Time.deltaTime;
        }
        else
        {
            coyoteTimeCounter = 0;
        }
    }
        

    
        
     private void setPhysics()
     {
         // formula de queda livre que fofo h = g * t² / 2 
         // como é movimento horizontal de descida por isso do -2;
         Vector2 newGravity = new Vector2(0, -2f * jumpHeight / (jumpApexTime * jumpApexTime));
         mistyRigid.gravityScale = (newGravity.y / Physics2D.gravity.y) * gravityMultiplier;
     }
         
         

     private void FixedUpdate()
     { 
         
         velocity = mistyRigid.velocity;
         if (desiredJump)
         {
             Jump();
             mistyRigid.velocity = velocity;
             return;
         }
         calculateGravity();
     }


     private void calculateGravity() // implorando por refatoração
     {
         if (mistyRigid.velocity.y > 0.01f) // subindo
         {
             if (onGround)
             {
                gravityMultiplier = defaultGravity;
             }
             else
            {
                if (variableJumpHeight)
                {
                    gravityMultiplier = (pressingJump && currentlyJumping) ? upGravityMultiplier : jumpCutOff;
                }
                else
                {
                    gravityMultiplier = upGravityMultiplier;
                }
            }
         }
                    
         else if (mistyRigid.velocity.y < -0.01f) // descendo
         {
             gravityMultiplier = onGround ? defaultGravity : downGravityMultiplier;
         }
         else
         {
             if (onGround)
             {
                 currentlyJumping = false;
             }

             gravityMultiplier = defaultGravity;
         }

         mistyRigid.velocity = new Vector2(velocity.x, Mathf.Clamp(velocity.y, -fallSpeedLimit, 100));
                    
                    
                 
         

     }

     private void Jump()
     {
         if (onGround || (coyoteTimeCounter > 0.03f) && coyoteTimeCounter < coyoteTime || canJumpAgain)
         {
             desiredJump = false;
             jumpBufferCounter = 0;
             coyoteTimeCounter = 0;

             canJumpAgain = (maxAirJump == 1 && canJumpAgain == false);
             // torriceli = v² = 2gh , como o movimento é pra baixo, -2f
             jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * mistyRigid.gravityScale * jumpHeight);

             if (velocity.y > 0f)
             {
                 jumpSpeed = Mathf.Abs(jumpSpeed - mistyRigid.velocity.y);
             }
             else if (velocity.y < 0f)
             {
                 jumpSpeed += Mathf.Abs(mistyRigid.velocity.y);
             }

             velocity.y += jumpSpeed;
             currentlyJumping = true;
             animationScript.JumpAnimation();
         }


         if (jumpBuffer == 0)
         {
             desiredJump = false;
         }
         
     }

     
     
     
}
