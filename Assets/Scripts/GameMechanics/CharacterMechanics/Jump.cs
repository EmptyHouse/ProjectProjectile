using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour {
    public float launchVelocity = 5;
    public float doubleJumpVelocity = 10;
    public bool jumpActive = true;

    bool doubleJumpActive;
    Rigidbody2D rigid;
    CustomGravity customGravity;
    GroundCollision groundCollision;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        customGravity = GetComponent<CustomGravity>();
        groundCollision = GetComponent<GroundCollision>();
    }

    void Update()
    {
        if (groundCollision.getIsGrounded()) doubleJumpActive = true;
    }

    public void jump(bool jumpInput)
    {
        if (!jumpActive) return;

        if (jumpInput && groundCollision.getIsGrounded())
        {
            rigid.velocity = rigid.velocity + (-customGravity.gravityDirection * launchVelocity);
            
        }
        else if (jumpInput && doubleJumpActive)
        {
            doubleJumpActive = false;
            rigid.velocity = rigid.velocity + (-customGravity.gravityDirection * doubleJumpVelocity);
        }
    }
}
