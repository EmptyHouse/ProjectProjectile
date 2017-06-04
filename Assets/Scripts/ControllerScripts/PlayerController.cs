using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    PlayerMechanics playerMechanics;

    private void Start()
    {
        playerMechanics = GetComponent<PlayerMechanics>();
    }

    private void Update()
    {
        playerMechanics.setHorizontalInput(Input.GetAxisRaw("Horizontal"));
        playerMechanics.setVerticalInput(Input.GetAxisRaw("Vertical"));
        playerMechanics.jump(Input.GetButtonDown("Jump"));
    }



}
