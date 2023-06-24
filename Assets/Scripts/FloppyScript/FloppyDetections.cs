using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class FloppyDetections : MonoBehaviour
{
    private readonly float wallOffSet = 0.5f;
    private readonly float airOffSet = 0.95f;
    private Vector3 wallColliderOffSet;
    private readonly Vector3 airColliderOffSet = new Vector2(0.65f, 0f);
    private bool onWall;
    private bool onEdge;
    [SerializeField] private LayerMask wallLayer;

    
    
    void Update()
    {
        // checkando a colisão com paredes;
        onWall = Physics2D.Raycast(transform.position - wallColliderOffSet, Vector2.left, wallOffSet, wallLayer) ||
                 Physics2D.Raycast(transform.position + wallColliderOffSet, Vector2.right, wallOffSet, wallLayer); 
        
        // checkando colisao com buraco/ espaços vazios para o floppy n cair e inverter o movimento

        onEdge = Physics2D.Raycast(transform.position + airColliderOffSet, Vector2.down, airOffSet) &&
                 Physics2D.Raycast(transform.position - airColliderOffSet, Vector2.down, airOffSet);
        
        
        /*// onwall debug
        Debug.DrawRay(transform.position - wallColliderOffSet, Vector2.left * wallOffSet);
        Debug.DrawRay(transform.position + wallColliderOffSet, Vector2.right * wallOffSet);
        
        // onedge debug
        Debug.DrawRay(transform.position + airColliderOffSet, Vector2.down * airOffSet);
        Debug.DrawRay(transform.position - airColliderOffSet, Vector2.down * airOffSet);*/
    }
    
    public bool GetFloppyWall()
    {
        return onWall;
    }
    public bool GetFloopyEdge()
    {
        return onEdge;
    }



        

    
}
