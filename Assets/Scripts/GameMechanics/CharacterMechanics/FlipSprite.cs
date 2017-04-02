using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour {
    public bool useScale = true;
    public bool flipActive = true;
    public bool isLeft = true;
    public bool startsLeft = true; //Set this to false if you drew the sprite sheet with the characters facing toward the right of the screen

    SpriteRenderer sprite;
    Movement movement;// Not sure if this is the best way to go about implementing direction...


	void Start () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        movement = GetComponent<Movement>();
        setDirection(isLeft);
	}
	

	void Update () {
        if (!flipActive) return;
        if (movement.getHorizontalInput() > .01f) isLeft = false;
        if (movement.getHorizontalInput() < -.01f) isLeft = true;
        setDirection(isLeft);
	}

    public void setDirection(bool isLeft)
    {
        //Even if flip is inActive you can still flip the sprite out side of the update function
        if (startsLeft) updateSpriteDirection(isLeft);
        else updateSpriteDirection(!isLeft);
    }
    
    void updateSpriteDirection(bool isLeft)
    {
        if (useScale)
        {
            if (isLeft)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (isLeft)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }
}
