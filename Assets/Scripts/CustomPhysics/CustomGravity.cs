using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CustomGravity : MonoBehaviour {
    public const float GRAVITY = 9.8f;
    public float gravityScale = 1;
    public float maxFallSpeed = 10;
    public bool gravityOn = true;
    public Vector2 gravityDirection = Vector2.down;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!gravityOn)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            return;
        }
        gravityDirection = gravityDirection.normalized;
        Vector2 gravPerpendicular = new Vector2(-gravityDirection.y * rigid.velocity.x, gravityDirection.x * rigid.velocity.y);

        rigid.velocity = Vector2.MoveTowards(rigid.velocity, (gravityDirection * maxFallSpeed) + gravPerpendicular, Time.fixedDeltaTime * GRAVITY * gravityScale);
        //print(rigid.velocity);
    }

    
}
