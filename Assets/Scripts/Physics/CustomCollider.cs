﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CustomPhysics))]
public class CustomCollider : MonoBehaviour {
    public int verticalRayCount;
    public int horizontalRayCount;
    [Tooltip("If this value is positive the corners will be positioned closer together when calculating horizontal rays")]
    public float horizontalOffset;
    [Tooltip("If this value is positive the corners will be positioned closer together when calculate vertical rays")]
    public float verticalOffset;
    public string[] layerMask;

    Collider2D boundedCollider;
    CustomPhysics rigid;
    BoundingCorners corners;


    private void Start()
    {
        boundedCollider = GetComponent<Collider2D>();
        rigid = GetComponent<CustomPhysics>();        
    }

    private void Update()
    {
        updateCorners();
        checkColliderHorizontal(rigid.velocity.x);
        checkColliderVertical(rigid.velocity.y);
    }

    private void LateUpdate()
    {
        
    }

    private void OnValidate()
    {
        if (verticalRayCount < 2) verticalRayCount = 2;
        if (horizontalRayCount < 2) horizontalRayCount = 2;
    }

    void checkColliderVertical(float yVel)
    {
        Vector2 left = corners.bottomLeft;
        Vector2 right = corners.bottomRight;
        if (yVel >= 0)
        {
            left = corners.topLeft;
            right = corners.topRight;
        }
        left.x += verticalOffset;
        right.x -= verticalOffset;
        Ray2D ray = new Ray2D();
        for (int i = 0; i < verticalRayCount; i++)
        {
            ray.origin = left + ((right - left) / (verticalRayCount - 1)) * i;
            ray.direction = (Vector2.up * yVel).normalized;
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(yVel) * Time.deltaTime, LayerMask.GetMask(layerMask));
            if (hit)
            {
                transform.position = new Vector3(transform.position.x, rigid.velocity.y <= 0 ? hit.collider.bounds.max.y : hit.collider.bounds.min.y, transform.position.z);
                rigid.velocity.y = 0;
            }
            //print(ray.direction);
            //print(Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(yVel) * Time.foxedDeltaTime));

            if (Settings.Instance.debugDraw)
            {
                DebugDrawRaycast(ray.origin, ray.origin + ray.direction * Mathf.Abs(yVel) * Time.deltaTime);
            }
        }
    }

    void checkColliderHorizontal(float xVel)
    {
        Vector2 top = corners.topRight;
        Vector2 bottom = corners.bottomRight;

        if (xVel < 0)
        {
            top = corners.topLeft;
            bottom = corners.bottomLeft;
        }
        top.y -= horizontalOffset;
        bottom.y += horizontalOffset;
        Ray2D ray = new Ray2D();

        for (int i = 0; i < horizontalRayCount; i++)
        {
            ray.origin = bottom + ((top - bottom) / (horizontalRayCount - 1)) * i;
            ray.direction = (Vector2.right * xVel).normalized;
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(xVel) * Time.deltaTime, LayerMask.GetMask(layerMask));
            if (hit)
            {
                GroundCollision groundCollision = hit.collider.GetComponent<GroundCollision>();
                if (groundCollision)
                {

                }
                
            }
            if (Settings.Instance.debugDraw)
            {
                DebugDrawRaycast(ray.origin, ray.origin + ray.direction * Mathf.Abs(xVel) * Time.deltaTime);
            }
        }
    }

    void updateCorners()
    {
        corners = new BoundingCorners();
        Bounds b = boundedCollider.bounds;
        corners.topLeft = new Vector2(b.min.x, b.max.y);
        corners.topRight = b.max;
        corners.bottomLeft = b.min;
        corners.bottomRight = new Vector2(b.max.x, b.min.y);
    }

    struct BoundingCorners
    {
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;
    }

    public void DebugDrawRaycast(Vector2 origin, Vector2 end)
    {
        Debug.DrawLine(origin, end, Color.red);
    }
}
