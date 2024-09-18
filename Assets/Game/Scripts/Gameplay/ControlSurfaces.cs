using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

[RequireComponent(typeof(AeroBody))]
public class ControlSurfaces : MonoBehaviour
{
    private AeroBody body
    {
        get { return GetComponent<AeroBody>(); }
    }
    private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }

    [SerializeField] private Transform elevatorLeft, elevatorRight;
    [SerializeField] private AnimationCurve steerCoef, pitchCoef;
    [SerializeField] private Vector3 turnAcceleration;
    [SerializeField] private Vector3 turnSpeed;
    [SerializeField] Vector3 accel;
    [SerializeField] private Vector3 localAngularVelocity;

    private float CalculateSteer(float target, float velocity,float acceleration)
    {
        float error = target - velocity;
        float accel = acceleration * Time.deltaTime;
        return Mathf.Clamp(error, -acceleration, acceleration);
    }

    
    private float CalculateGlimit(float input)
    {
        float maxG = 14;
        float gDiff = maxG - body.G;
        return (input / gDiff);
    }

    private void UpdateSteer(Vector3 controlInput)
    {
        var localVelocity = Quaternion.Inverse(rb.rotation) * rb.velocity;
        var speed = Mathf.Max(0, (localVelocity).z);
        var steerPower = steerCoef.Evaluate(speed);
        var localAV = Quaternion.Inverse(rb.rotation) * rb.angularVelocity;
        var targetVelocity = Vector3.Scale(controlInput, turnSpeed);
        var correction = new Vector3(CalculateSteer(targetVelocity.x, localAV.x, turnAcceleration.x),
            CalculateSteer(targetVelocity.y, localAV.y, turnAcceleration.y),
            CalculateSteer(targetVelocity.z, localAV.z, turnAcceleration.z));
            rb.AddRelativeTorque(correction * steerPower,ForceMode.VelocityChange);
      
        ElevatorAnimation(controlInput.x, elevatorLeft);
        ElevatorAnimation(controlInput.x, elevatorRight);
        
        float EffectiveG = controlInput.x * CalculateGlimit(controlInput.x);
        controlInput.x = EffectiveG;
    }
    private void ElevatorAnimation(float input, Transform elevator)
    {
        Quaternion targetRotation = Quaternion.AngleAxis(-75 * input, Vector3.right);

        Vector3 diff = targetRotation.eulerAngles;

        Quaternion newRotation = Quaternion.Euler(diff);

        elevator.localRotation = Quaternion.Slerp(elevator.localRotation, newRotation, turnAcceleration.magnitude * Time.deltaTime);
    }
    private void UpdateControl()
    {



        // float steerX = Steer(currentVelocity.x, steerInput.x,  Mathf.Max(0,currentVelocity.z) * pitchSpeed);
        // float steerY = Steer(currentVelocity.y, steerInput.y * yawSpeed, accel.y);
        //  float steerZ = Steer(currentVelocity.z, steerInput.z * turnSpeed, accel.z);

        //  Vector3 steerForce = new Vector3(steerX, steerY, steerZ);

        UpdateSteer(new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")));
 


    }
    private void Update()
    { 
    }
    private void FixedUpdate()
    {

        UpdateControl();

    }
}
