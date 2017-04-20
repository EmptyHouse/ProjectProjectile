using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDirectionRight : MonoBehaviour {
    public float lineLength = 2;

	
	// Update is called once per frame
	void Update () {
		if (DebugSettings.Instance.displayForwardVectors)
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * lineLength, Color.red);
        }
	}
}
