using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour {
    public const float GRAVITY = 9.8f;

    [Tooltip("Use these points that will act as origin points for our Raycast that will check to see if we are colliding with a ground object")]
    public Transform[] inAirCheckPoints;
    [Tooltip("The direction of gravity that will be applied to this object")]
    private Vector2 gravityDirection = Vector2.down;//We are locking gravity to strictly just down for now
    [Tooltip("The scale of gravity acceleration")]
    public float gravityScale = 1;
    [Tooltip("The maximum falling velocity.")]
    public float terminalVelocity;

    [System.NonSerialized]
    public bool inAir;

    [System.NonSerialized]
    public Vector2 velocity;

    private void Start()
    {
        gravityDirection = gravityDirection.normalized;    
    }

    private void Update()
    {
        updateTransformPosition();
        applyGravity();
        //print(velocity);
    }


    
    void updateTransformPosition()
    {
        transform.position = transform.position + (new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime);
    }

    void applyGravity()
    {
        velocity = Vector2.MoveTowards(velocity, new Vector2(velocity.x, 0) + gravityDirection * terminalVelocity, Time.deltaTime * GRAVITY * gravityScale);
    }
}
