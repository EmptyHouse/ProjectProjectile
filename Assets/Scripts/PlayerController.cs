﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Movement movement;
    Jump jump;
    BowMechanics bowMechanics;

    void Start()
    {
        movement = GetComponent<Movement>();
        bowMechanics = GetComponentInChildren<BowMechanics>();
        jump = GetComponent<Jump>();
    }

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");

        movement.setHorizontalInput(hInput);
        jump.jump(Input.GetButtonDown("Jump"));
        bowMechanics.setDirectionDown(Input.GetButton("DirectionDown"));
        bowMechanics.setDirectionUp(Input.GetButton("DirectionUp"));
        bowMechanics.fire(Input.GetButtonDown("Fire"));
    }



}