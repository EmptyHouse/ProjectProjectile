using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CustomPhysics))]
public class CustomCollider : MonoBehaviour {
    public int verticalRayCount;
    public int horizontalRayCount;

    Collider2D boundedCollider;
    CustomPhysics rigid;
    BoundingCorners corners;


    private void Start()
    {
        boundedCollider = GetComponent<Collider2D>();
        rigid = GetComponent<CustomPhysics>();
        corners = new BoundingCorners();
        Bounds b = boundedCollider.bounds;
        corners.topLeft = new Vector2(b.min.x, b.max.y);
        corners.topRight = b.max;
        corners.bottomLeft = b.min;
        corners.bottomRight = new Vector2(b.max.x, b.min.y);

        print(corners.topLeft);
        print(corners.topRight);
        print(corners.bottomLeft);
        print(corners.bottomRight);
    }

    private void Update()
    {
        checkColliderHorizontal(rigid.velocity.x);
        checkColliderVertical(rigid.velocity.y);

        
    }

    private void OnValidate()
    {
        if (verticalRayCount < 2) verticalRayCount = 2;
        if (horizontalRayCount < 2) horizontalRayCount = 2;
    }

    void checkColliderVertical(float yVel)
    {

    }

    void checkColliderHorizontal(float xVel)
    {

    }

    struct BoundingCorners
    {
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;
    }

    public void DebugDraw()
    {

    }
}
