using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float followSpeed = 10;

    private Vector3 offsetVector;
    private Transform targetTransform;

    #region Monobehaviour
    private void Start()
    {
        if (!this.transform.parent)
        {
            Debug.LogWarning("The camera does not have a parent object associated with it. Please parent the camera to the object you would like to follow.");
            this.enabled = false;
            return;
        }
        
        targetTransform = this.transform.parent;
        offsetVector = this.transform.position - targetTransform.position;
        this.transform.SetParent(null);
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetTransform.position + offsetVector, Time.deltaTime * followSpeed);
    }
    #endregion Monobehaviour

    public void SetNewTargetFollow(Transform targetTransform, Vector3 offsetVector = new Vector3())
    {
        this.targetTransform = targetTransform;
        this.offsetVector = offsetVector;
    }
}
