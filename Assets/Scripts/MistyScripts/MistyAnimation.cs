using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistyAnimation : MonoBehaviour
{
    Rigidbody2D mistyRigid;
    Animator mistyAnimator;
    MistyMovement runScript;
    MistyJump jumpScript;
    private float runningSpeed;
    [SerializeField] private float maxSpeed = 8.0f;
    private bool playerGrounded;
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Landed = Animator.StringToHash("Landed");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private void Start()
    {
        runScript = GetComponent<MistyMovement>();
        jumpScript = GetComponent<MistyJump>();
        mistyAnimator = GetComponent<Animator>();
    }
        

    private void Update()
    {
        runningSpeed = Mathf.Clamp(Mathf.Abs(runScript.velocity.x), 0, maxSpeed);
        mistyAnimator.SetFloat(Running, runningSpeed);
        
        
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
}
