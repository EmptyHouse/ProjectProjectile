using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    public 
    Transform parentObject;

    void Start()
    {
        parentObject = this.transform;
        while (parentObject.parent != null)
        {
            parentObject = parentObject.parent;
        }
    }

    public Transform getParentTransform()
    {
        return parentObject;
    }

    public bool checkTakeDamage(Hitbox hbox)
    {
        return false;
    }
}
