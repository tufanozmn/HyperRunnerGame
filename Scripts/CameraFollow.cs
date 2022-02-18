using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;

    /*void Start() 
    {
        cameraOffset = transform.position - targetObject.transform.positinon;
    }*/


    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if(lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }






    /*public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    
    void FixedUpdate()
    {
        Vector3 desiredPosition =  target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = target.position + offset;;

        transform.LookAt(target);
    }*/
}
