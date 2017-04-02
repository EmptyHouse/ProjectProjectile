using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed;

    Transform target;
    Vector3 offset;

    void Start()
    {
        Transform p = transform.parent;
        while (p.parent != null)
        {
            p = p.parent;
        }

        float xOffset = this.transform.position.x - p.position.x;
        float yOffset = this.transform.position.y - p.position.y;
        float zOffset = this.transform.position.z - p.position.z;
        this.target = p;
        this.transform.parent = null;
        offset = new Vector3(xOffset, yOffset, zOffset);
    }


    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position + offset, Time.deltaTime * speed);
    }

}
