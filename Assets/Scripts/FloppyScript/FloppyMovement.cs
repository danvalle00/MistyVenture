using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyMovement : MonoBehaviour
{
    private Rigidbody2D floppyRigid;
    private Animator floppyAnimator;
    private FloppyDetections floppyChecks;
    [SerializeField] private float floppyVelocity = -1.0f;




    void Start()
    {
        floppyRigid = GetComponent<Rigidbody2D>();
        floppyAnimator = GetComponent<Animator>();
        floppyChecks = GetComponent<FloppyDetections>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        floppyRigid.velocity = new Vector2(floppyVelocity, floppyRigid.velocity.y);
    }

    void Update()
    {
        
        // invertendo a direção da velocidade ao colidir
        if (floppyChecks.GetFloppyWall())
        {
            FloppyScaleInversion();
        }
        else if (!floppyChecks.GetFloopyEdge())
        {
            FloppyScaleInversion();    
        }
        else if (floppyChecks.GetFloopyFloppy())
        {
            FloppyScaleInversion();
        }

    }

    void FloppyScaleInversion()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        floppyVelocity *= -1;
    }





    }
