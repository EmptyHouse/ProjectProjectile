using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionNode : MonoBehaviour {
    public SelectionNode NORTH;
    public SelectionNode SOUTH;
    public SelectionNode EAST;
    public SelectionNode WEST;

    public Transform pointerPosition;
    public UnityEvent actionOnAccept;

    public void acceptAction()
    {
        actionOnAccept.Invoke();
        //print("Action invoked");
    }
}
