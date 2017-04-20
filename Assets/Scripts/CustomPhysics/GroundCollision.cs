using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomGravity))]

public class GroundCollision : MonoBehaviour {
    public Transform[] collisionPoints;
    public float maxDistance = .05f;
    CustomGravity customGravity;
    Rigidbody2D rigid;
    int layerMask;
    bool isGrounded;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        customGravity = GetComponent<CustomGravity>();
        layerMask = 0;
        layerMask += (1 << LayerMask.NameToLayer("Ground"));
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("InAir", !isGrounded);
        checkHitGround();
    }

    void checkHitGround()
    {
        
        RaycastHit2D hit;
        customGravity.gravityOn = true;
        isGrounded = false;
        if (rigid.velocity.y > .01f) return;
        foreach (Transform t in collisionPoints)
        {
            hit = Physics2D.Raycast(t.position, customGravity.gravityDirection, maxDistance, layerMask);
            if (hit)
            {
                customGravity.gravityOn = false;
                Vector2 newPosition = new Vector2(transform.position.x, hit.collider.bounds.max.y);
                transform.position = newPosition;
                isGrounded = true;
            }
        }
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
