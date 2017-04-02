﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    Transform parentObject;

    void Start()
    {
        parentObject = this.transform;
        while (parentObject.parent != null)
        {
            parentObject = parentObject.parent;
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {

    }
}
