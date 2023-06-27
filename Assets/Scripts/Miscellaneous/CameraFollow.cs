using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform cameraTarget;
   [SerializeField] private float smoothSpeed;
   [SerializeField] private Vector3 offSet;

   private void LateUpdate()
   {
      Vector3 desiredPosition = cameraTarget.position + offSet;
      Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
      transform.position = smoothedPosition;
   }
      
      
}
