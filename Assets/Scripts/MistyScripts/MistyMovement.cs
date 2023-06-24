using UnityEngine;


public class MistyMovement : MonoBehaviour
{
    private Rigidbody2D mistyRigid;
    private MistyGroundCheck ground;
    
    

    // Stats de Movimento de Misty
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxAcceleration = 52f;
    [SerializeField] private float maxDecceleration = 52f;
    [SerializeField] private float maxTurnSpeed = 80f;
    [SerializeField] private float friction;
    
    // Calculos 
    private float directionX;
    private Vector2 desiredVelocity;
    public Vector2 velocity;
    private float acceleration;
    private float maxSpeedChange;
    private float decceleration;
    private float turnspeed;
    
    // Estado
    private bool onGround;
    private bool pressingKey;

    private void Awake()
    {
        mistyRigid = GetComponent<Rigidbody2D>();
        ground = GetComponent<MistyGroundCheck>();
    }

    private void onMoviment()
    {
        directionX = Input.GetAxisRaw("Horizontal");
    }

    private void Update()
    {
        onMoviment();
        if (directionX != 0) // != 0 quer dizer que está em movimento
        {
            transform.localScale = new Vector3(directionX > 0 ? 1 : -1, 1, 1); // muda a direção do spirte
            pressingKey = true;
        }
        else
        {
            pressingKey = false;
        }

        desiredVelocity = new Vector2(directionX, 0f) * Mathf.Max(maxSpeed - friction, 0f);

    }

    private void FixedUpdate() // para calculos de fisica na unity
    {
        onGround = ground.GetOnGround();
        velocity = mistyRigid.velocity;
        runMoviment();
    }
    
    private void runMoviment()
    {
        acceleration = maxAcceleration;
        decceleration = maxDecceleration;
        turnspeed = maxTurnSpeed;
        if (pressingKey)
        {
            if (Mathf.Sign(directionX) != Mathf.Sign(velocity.x)) // checkando se a direção do input corresponde a direção da velocidade
            {
                maxSpeedChange = turnspeed * Time.deltaTime;
            }
            else
            {
                maxSpeedChange = acceleration * Time.deltaTime;
            }
        }
        else
        {
            maxSpeedChange = decceleration * Time.deltaTime;
        }

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        mistyRigid.velocity = velocity;

    }
}

