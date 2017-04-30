using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerMechanics : MonoBehaviour {
    public float maxGroundSpeed;
    public float maxAirSpeed;

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
}
