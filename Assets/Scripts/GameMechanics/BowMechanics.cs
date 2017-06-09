using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomPhysics))]
public class BowMechanics : MonoBehaviour {
    CustomPhysics rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<CustomPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
        updateBowDirection();
	}

    private void updateBowDirection()
    {
        float x = rigid.velocity.x;
        float y = rigid.velocity.y;

        float degrees = Mathf.Rad2Deg * (Mathf.Atan2(y, x));

        this.transform.rotation = Quaternion.Euler(Vector3.forward * degrees);

    }
}
