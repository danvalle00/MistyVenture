using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misty_moviment : MonoBehaviour
{
    Rigidbody2D misty_rigid;
    private float h_input;
    private bool v_input;
    // private bool isJumping = false;
    [SerializeField] private float vel = 4.0f;
    [SerializeField] private float jump_force = 5.0f;
    [SerializeField] private float friction = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        misty_rigid = GetComponent<Rigidbody2D>();
        misty_rigid.drag = friction;
    }

    // Update is called once per frame
    void Update()
    {
        h_input = Input.GetAxis("Horizontal");
        v_input = Input.GetButtonDown("Jump");
        misty_rigid.AddForce(new Vector2(h_input, 0) * vel, ForceMode2D.Force);
        if (v_input)
        {
            misty_rigid.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
            // isJumping = true;
        }
        else
        {
            // isJumping = false;
        }
    }
            
}
