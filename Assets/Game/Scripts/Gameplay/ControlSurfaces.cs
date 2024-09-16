using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;


public class ControlSurfaces : MonoBehaviour
{
    private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }

    [SerializeField] private Transform elevatorLeft, elevatorRight;
    [SerializeField] private AnimationCurve steerCoef, pitchCoef;

    [SerializeField] private float turnSpeed,pitchSpeed,yawSpeed;
    [SerializeField] Vector3 accel;
    [SerializeField] private Vector3 localAngularVelocity;
    Vector3 currentVelocity;
    Vector3 finalVelocity = Vector3.zero;

    void CalculateSteer(Vector3 targetVelocity)
    {

        localAngularVelocity = Quaternion.Inverse(rb.rotation) * rb.angularVelocity;
        currentVelocity = Quaternion.Inverse(rb.rotation) * rb.velocity;

        float speed = Mathf.Max(0, currentVelocity.z);
       
        finalVelocity.x = steerCoef.Evaluate(speed) * pitchSpeed * targetVelocity.x;
        finalVelocity.y = steerCoef.Evaluate(speed) * yawSpeed * targetVelocity.y;
        finalVelocity.z = steerCoef.Evaluate(speed) * turnSpeed * targetVelocity.z;
        Vector3 finalTorque = (finalVelocity - localAngularVelocity * Mathf.Max(0, currentVelocity.z));




        rb.AddRelativeTorque(finalTorque * Mathf.Deg2Rad, ForceMode.VelocityChange);
    }
    private void UpdateControl()
    {

      

       // float steerX = Steer(currentVelocity.x, steerInput.x,  Mathf.Max(0,currentVelocity.z) * pitchSpeed);
       // float steerY = Steer(currentVelocity.y, steerInput.y * yawSpeed, accel.y);
      //  float steerZ = Steer(currentVelocity.z, steerInput.z * turnSpeed, accel.z);
    
      //  Vector3 steerForce = new Vector3(steerX, steerY, steerZ);

        
        CalculateSteer(new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")));


    }
    private void Update()
    { 
    }
    private void FixedUpdate()
    {

        UpdateControl();

    }
}
