using UnityEngine;

public class FloppyDetections : MonoBehaviour
{
    private readonly float wallOffSet = 0.5f;
    private readonly float airOffSet = 0.95f;
    private Vector3 wallColliderOffSet;
    private readonly Vector3 airColliderOffSet = new Vector2(0.65f, 0f);
    private readonly Vector3 floppyColliderOffSet = new Vector2(1f, 0f);
    private bool onWall;
    private bool onEdge;
    private bool onFloppy;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask floppyLayer;



    void Update()
    {
        // checkando a colisão com paredes;
        onWall = Physics2D.Raycast(transform.position - wallColliderOffSet, Vector2.left, wallOffSet, wallLayer) ||
                 Physics2D.Raycast(transform.position + wallColliderOffSet, Vector2.right, wallOffSet, wallLayer); 
        
        // checkando colisao com buraco/ espaços vazios para o floppy n cair e inverter o movimento

        onEdge = Physics2D.Raycast(transform.position + airColliderOffSet, Vector2.down, airOffSet) &&
                 Physics2D.Raycast(transform.position - airColliderOffSet, Vector2.down, airOffSet);
        
        /*// checkar com outro floppy n consegui implementar sadge
        onFloppy = Physics2D.Raycast(transform.position + floppyColliderOffSet , Vector2.left, floppyLayer) ||
                 Physics2D.Raycast(transform.position - floppyColliderOffSet, Vector2.right, floppyLayer); 
        
        
        Debug.DrawRay(transform.position + floppyColliderOffSet, Vector2.left);
        Debug.DrawRay(transform.position - floppyColliderOffSet, Vector2.right);*/
        
       
    }
    
    public bool GetFloppyWall()
    {
        return onWall;
    }
    public bool GetFloopyEdge()
    {
        return onEdge;
    }
    public bool GetFloopyFloppy()
    {
        return onFloppy;
    }



        

    
}
