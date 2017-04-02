using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    public float pointerSpeed = 10;

    SelectionManager selectionManager;

	// Use this for initialization
	void Start () {
        selectionManager = transform.parent.GetComponent<SelectionManager>();
        setPosition(selectionManager.currentNode.pointerPosition);
	}
	
	// Update is called once per frame
	void Update () {
        Transform destination = selectionManager.currentNode.pointerPosition;
        if (destination != null)
        {
            transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * pointerSpeed);
        }
	}

    public void setPosition(Transform t)
    {
        if (t == null) return;
        setPosition(t.position);
    }

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
