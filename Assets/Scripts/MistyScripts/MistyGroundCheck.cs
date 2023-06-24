using UnityEngine;

public class MistyGroundCheck : MonoBehaviour
{
    private bool onGround;
    private readonly float groundOffset = 0.95f;
    private Vector3 colliderOffset;
    [SerializeField] private LayerMask groundLayer;
    private void Update()
    {
        
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundOffset, groundLayer) ||
                   Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundOffset, groundLayer);
    }
    

    public bool GetOnGround()
    {
        return onGround;
    }

}
    