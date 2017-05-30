using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class GroundCollision : MonoBehaviour {
    [Tooltip("Use this setting if you want the character to be able to pass through this platfrom from the bottom.")]
    public bool isOneWayCollider;
    
    Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();

    }



    public virtual void setCharacterToPlane(CustomPhysics rigid)
    {
        if (isOneWayCollider && rigid.velocity.y > 0)
        {
            rigid.inAir = true;
            rigid.transform.position = new Vector3(rigid.transform.position.x, collider.bounds.max.y, rigid.transform.position.z);
            return;
        }
        rigid.inAir = false;

    }
}
