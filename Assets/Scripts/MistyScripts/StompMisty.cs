using UnityEngine;

public class StompMisty : MonoBehaviour
{
    public float bounceForce;
    public Rigidbody2D mistyRigid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floppy"))
        {
            Destroy(other.gameObject);
            mistyRigid.velocity = new Vector2(mistyRigid.velocity.x, bounceForce);
        }
    }
 
}
