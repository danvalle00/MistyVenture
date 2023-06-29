
using UnityEngine;


public class MistyHurting : MonoBehaviour
{
    private Vector3 checkpointFlag;
    private Vector3 mistyInitialPoint;
    public Transform flagTransform;
    private bool hurting;
    private bool flagRespawn = false;

  
    
    private void Start()
    {
        mistyInitialPoint = transform.position;
        flagTransform = GetComponent<Transform>();
    }
    
    // pegando a posição da flag para setar o novo respawn
    private void OnTriggerEnter2D(Collider2D flagTrigger)
    {
        if (flagTrigger.gameObject.CompareTag("Flag"))
        {
            checkpointFlag = flagTransform.position;
            flagRespawn = true;
        }
            
    }
    
    

       
       


    private void OnCollisionEnter2D(Collision2D other)
    {
        // layer do espinho
        if (other.gameObject.layer == 7 || other.gameObject.layer == 8) // floppy e espinho
        {
            ScoreManager.instance.ResetScore();

            transform.position = flagRespawn ? checkpointFlag : mistyInitialPoint;
        }
            
    }
}

