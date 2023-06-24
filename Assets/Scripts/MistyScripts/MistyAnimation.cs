using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistyAnimation : MonoBehaviour
{
    private MistyMovement movementScript;
    Animator mistyAnimator;
    MistyJump jumpScript;
    private bool playerGrounded;
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Landed = Animator.StringToHash("Landed");
    private static readonly int Jump = Animator.StringToHash("Jump");
    
    
    

    private void Start()
    {
        
        jumpScript = GetComponent<MistyJump>();
        mistyAnimator = GetComponent<Animator>();
        movementScript = GetComponent<MistyMovement>();
    }
        

    private void Update()
    {
        HorizontalAnimation();
        checkLanded();
    }
        
        

    void checkLanded()
    {
        if (!playerGrounded && jumpScript.onGround)
        {
            playerGrounded = true;
            mistyAnimator.SetTrigger(Landed);
        }
        else if (playerGrounded && !jumpScript.onGround)
        {
            playerGrounded = false;
        }
    }

    public void JumpAnimation()
    {
        mistyAnimator.ResetTrigger(Landed);
        mistyAnimator.SetTrigger(Jump);
        
    }

    private void HorizontalAnimation()
    {
        mistyAnimator.SetBool(Running, Mathf.Abs(movementScript.directionX) > 0f);
    }
}
