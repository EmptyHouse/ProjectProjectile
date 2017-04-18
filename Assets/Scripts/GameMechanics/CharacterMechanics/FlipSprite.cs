using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour {
    public bool useScale = true;
    public bool flipActive = true;
    public bool isRight = true;
    //public bool startsLeft = true; //Set this to false if you drew the sprite sheet with the characters facing toward the right of the screen

    SpriteRenderer sprite;
    Movement movement;// Not sure if this is the best way to go about implementing direction...


	void Start () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        movement = GetComponent<Movement>();
        setDirection(isRight);
	}
	

	void Update () {
        if (!flipActive) return;
        if (movement.getHorizontalInput() > .01f) isRight = true;
        if (movement.getHorizontalInput() < -.01f) isRight = false;
        setDirection(isRight);
	}

    public void setDirection(bool isRight)
    {
        //Even if flip is inActive you can still flip the sprite out side of the update function
        updateSpriteDirection(isRight);
    }
    
    void updateSpriteDirection(bool isRight)
    {
        if (useScale)
        {
            if (isRight)
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
            if (isRight)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }

    /// <summary>
    /// This method is used whenever there is an animation that requres 
    /// transform movement of the sprite
    /// </summary>
    public void resetTransformToSprite()
    {
        transform.position = sprite.transform.position;
        sprite.transform.localPosition = Vector3.zero;
    }
}
