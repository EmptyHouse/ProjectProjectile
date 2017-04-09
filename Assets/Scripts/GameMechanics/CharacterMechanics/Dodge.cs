using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour {
    public bool dodgeActive = true;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void dodge(bool dodgeInput)
    {
        if (dodgeInput && dodgeActive)
        {
            anim.SetTrigger("Dodge");
        }
    }	
}
