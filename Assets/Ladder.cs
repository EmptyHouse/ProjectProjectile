using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    public static float PlayerClimbSpeed = 1;
    PlayerController playerController;
    Animator playerAnim;
    Rigidbody2D playerRigid;
    //CustomGravity playerCustomGravity;
    bool playerClimbing;

    void FixedUpdate()
    {
        if (playerController && Mathf.Abs(playerController.getInput()) > .5f) playerClimbing = true;
        if (Input.GetButtonDown("Jump")) playerClimbing = false;
        if (playerAnim) playerAnim.SetBool("Climbing", playerClimbing);
        if (playerController && playerClimbing)
        {
            if (!playerAnim) playerAnim = playerController.GetComponent<Animator>();
            if (!playerRigid) playerRigid = playerController.GetComponent<Rigidbody2D>();

            float vInput = playerController.getInput();
            if (vInput > .5f)
            {
                climbUp(true);
            }
            else if (vInput < -.5f)
            {
                climbUp(false);
            }
            else
            {
                playerAnim.speed = 0;
                playerRigid.velocity = Vector2.zero;
            }
        }
        
    }

    void climbUp(bool isUp)
    {
        playerController.transform.position = new Vector3(transform.position.x, playerController.transform.position.y, playerController.transform.position.z);

        if (isUp)
        {
            playerRigid.velocity = new Vector2(0, PlayerClimbSpeed);
        }
        else
        {
            playerRigid.velocity = new Vector2(0, -PlayerClimbSpeed);
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        PlayerController p = collider.GetComponent<PlayerController>();
        if (p)
        {
           playerController = p;
        }
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        PlayerController p = collider.GetComponent<PlayerController>();
        if (p)
        {
            cleanUp();
        }
    }

    void cleanUp()
    {
        if (playerAnim)
        {
            playerAnim.speed = 1;
            playerAnim = null;
            playerAnim.SetBool("Climbing", false);
        }

        if (playerRigid)
        {
            playerRigid = null;
        }
        playerController = null;
    }
}
