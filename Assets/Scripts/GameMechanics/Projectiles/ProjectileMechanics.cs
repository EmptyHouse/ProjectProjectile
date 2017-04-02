using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ProjectileMechanics : MonoBehaviour {
    public Vector2 launchDirection = Vector2.right;
    public float maxLaunchSpeed = 5;
    public bool updateDirection = true;

    Rigidbody2D rigid;

    protected virtual void Awake()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;        
    }

    protected virtual void Update()
    {
        if (rigid.velocity == Vector2.zero) updateProjectileRotation(launchDirection.x, launchDirection.y);
        else if (updateDirection) updateProjectileRotation();
        rigid.velocity = launchDirection * maxLaunchSpeed;

    }

    public void updateProjectileRotation()
    {
        this.updateProjectileRotation(rigid.velocity.x, rigid.velocity.y);
    }

    public void updateProjectileRotation(float x, float y)
    {
        float direction = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        direction += 180;
        //print(direction + " X = " + x + " Y = " + y);
        setRotation(direction);
    }

    public void setRotation(float zRotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }

    public virtual void launch()
    {
        launch(launchDirection);
    }

    public virtual void launch(Vector2 direction)
    {
        launchDirection = direction;
        rigid.velocity = direction.normalized * maxLaunchSpeed;        
    }
}
