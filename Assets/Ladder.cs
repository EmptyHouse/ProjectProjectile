using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    public static float PlayerClimbSpeed = 1;
    PlayerController playerController;
    Animator playerAnim;
    Rigidbody2D playerRigid;
    CustomGravity playerCustomGravity;

    void FixedUpdate()
    {
        if (playerController)
        {
            if (!playerAnim) playerAnim = playerController.GetComponent<Animator>();
            if (!playerRigid) playerRigid = playerController.GetComponent<Rigidbody2D>();
            if (!playerCustomGravity)
            {
                playerCustomGravity = playerController.GetComponent<CustomGravity>();
                playerCustomGravity.enabled = false;
            }

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
            if (playerAnim)
            {
                playerAnim.speed = 1;
                playerAnim = null;
            }

            if (playerRigid)
            {
                playerRigid = null;
            }
            if (playerCustomGravity)
            {
                playerCustomGravity.enabled = true;
                playerCustomGravity = null;
            }
            playerController = null;
        }
    }
}
