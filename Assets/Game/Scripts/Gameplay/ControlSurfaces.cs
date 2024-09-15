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
    private Vector3 steerInput { get; set; }
    [SerializeField] Vector3 accel;
    [SerializeField] Vector3 control = Vector3.zero;
    [SerializeField] private Vector3 localAngularVelocity;
    Vector3 currentVelocity;
    private float Steer(float currentVelocity,float targetVelocity,float acceleration)
    {
        float error = (targetVelocity - currentVelocity);
        float accel = acceleration * Time.deltaTime;
        return Mathf.Clamp(error,-accel,accel);
    }

    public void CalculateSteerInput(float x,float y,float z)
    {


        control.x = x;
        control.y = steerCoef.Evaluate(y);
        control.z = steerCoef.Evaluate(z);
        steerInput = control;
        
    }

    void CalculateSteer(Vector3 targetVelocity)
    {

        

        Vector3 error = targetVelocity - localAngularVelocity * Mathf.Max(0, currentVelocity.z);


        rb.AddRelativeTorque(error * Mathf.Deg2Rad, ForceMode.VelocityChange);
    }
    private void UpdateControl()
    {

        localAngularVelocity = Quaternion.Inverse(rb.rotation) * rb.angularVelocity;
        currentVelocity = Quaternion.Inverse(rb.rotation) * rb.velocity;

        float steerX = Steer(currentVelocity.x, steerInput.x,  Mathf.Max(0,currentVelocity.z) * pitchSpeed);
        float steerY = Steer(currentVelocity.y, steerInput.y * yawSpeed, accel.y);
        float steerZ = Steer(currentVelocity.z, steerInput.z * turnSpeed, accel.z);
   
        Vector3 steerForce = new Vector3(steerX, steerY, steerZ);
        CalculateSteer(new Vector3(Input.GetAxis("Vertical") * pitchSpeed, 0, Input.GetAxis("Horizontal") * turnSpeed));


    }
    private void Update()
    { 
    }
    private void FixedUpdate()
    {

        UpdateControl();

    }
}
