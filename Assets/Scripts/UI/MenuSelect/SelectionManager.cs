using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {
    public float deadZone = 0.2f;
    public SelectionNode currentNode;

    float inputVertical;
    float inputHorizontal;
    bool canMove;
    bool acceptAction;

    
    void Start()
    {
        if (currentNode == null)
        {
            //May possibly want to add a getcomponent in here just in case I think
            print("Please set initial SelectionNode in " + this.transform.name);
        }
    }

	// Update is called once per frame
	void Update () {
        acceptAction = Input.GetButtonDown("Submit");
        inputVertical = Input.GetAxisRaw("Vertical");
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (acceptAction)
        {
            //print("I was accepted");
            currentNode.acceptAction();
        }
        if (Mathf.Abs(inputVertical) < deadZone && Mathf.Abs(inputHorizontal) < deadZone)
        {
            canMove = true;
            return;
        }
        if (canMove)
        {
            updateNodeSelected();
        }
	}

    void updateNodeSelected()
    {

        if (Mathf.Abs(inputVertical) > deadZone)
        {
            if (inputVertical > 0 && currentNode.NORTH != null)
            {
                currentNode = currentNode.NORTH;
                canMove = false;
                return;
            }
            else if (currentNode.SOUTH != null)
            {
                currentNode = currentNode.SOUTH;
                canMove = false;
                return;
            }
        }

        if (Mathf.Abs(inputHorizontal) > deadZone)
        {
            if (inputHorizontal > 0 && currentNode.EAST != null)
            {
                currentNode = currentNode.EAST;
                canMove = false;
                return;
            }
            else if (currentNode.WEST != null)
            {
                currentNode = currentNode.WEST;
                canMove = false;
                return;
            }
        }
    }
}
