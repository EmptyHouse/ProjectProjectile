using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {
    public float deadZone = 0.2f;
    public SelectionNode currentNode;

    float inputVertical;
    float inputHorizontal;
    bool canMove;
    
    void Start()
    {
        if (currentNode == null)
        {
            print("Please set initial SelectionNode in " + this.transform.name);
        }
    }

	// Update is called once per frame
	void Update () {
        inputVertical = Input.GetAxisRaw("Vertical");
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
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
