using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(AeroBody))]
public class ControlSurfaces : MonoBehaviour
{
    Jet jet
    {
        get { return GetComponent<Jet>(); }
    }
    private AeroBody body
    {
        get { return GetComponent<AeroBody>(); }
    }
    private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }

    [SerializeField] private Transform elevatorLeft, elevatorRight;
    [SerializeField] Vector3 accel;
    [SerializeField] private Vector3 localAngularVelocity;
    private Vector3 controlInputX;
    private float CalculateSteer(float target, float velocity,float acceleration)
    {
        float error = target - velocity;
        float accel = acceleration * Time.deltaTime;
        return Mathf.Clamp(error, -acceleration, acceleration);
    }

    
    private float CalculateGAxis(float input,float gAxis)
    {
        
       
        return gAxis * input;
    }

    public void UpdateSteer(Vector3 controlInput)
    {
        this.controlInputX = controlInput;
        Vector3 gForce = body.CalculateGForce();
        body.G = gForce;
        if (Mathf.Abs(body.G.magnitude) > 6)
        {
            this.controlInputX = Vector3.Scale(controlInput, gForce);
        }
        var localVelocity = Quaternion.Inverse(rb.rotation) * rb.velocity;
        var speed = Mathf.Max(0, (localVelocity).z);
        var steerPower = jet.SteerCoef.Evaluate(speed);
        var localAngularVelocity = Quaternion.Inverse(rb.rotation) * rb.angularVelocity;
        var targetVelocity = Vector3.Scale(controlInput, jet.TurnSpeed);
        var correction = new Vector3(CalculateSteer(targetVelocity.x, localAngularVelocity.x, jet.TurnAcceleration.x),
            CalculateSteer(targetVelocity.y, localAngularVelocity.y, jet.TurnAcceleration.y),
            CalculateSteer(targetVelocity.z, localAngularVelocity.z, jet.TurnAcceleration.z));
            rb.AddRelativeTorque(correction * steerPower,ForceMode.VelocityChange);
      
        ElevatorAnimation(this.controlInputX.x, elevatorLeft);
        ElevatorAnimation(this.controlInputX.x, elevatorRight);

      
       
    }
    private void ElevatorAnimation(float input, Transform elevator)
    {
        Quaternion targetRotation = Quaternion.AngleAxis(-75 * input, Vector3.right);

        Vector3 diff = targetRotation.eulerAngles;

        Quaternion newRotation = Quaternion.Euler(diff);

        elevator.localRotation = Quaternion.Slerp(elevator.localRotation, newRotation, jet.TurnAcceleration.normalized.magnitude * Time.deltaTime * 15f);
    }
    private void UpdateControl()
    {



        // float steerX = Steer(currentVelocity.x, steerInput.x,  Mathf.Max(0,currentVelocity.z) * pitchSpeed);
        // float steerY = Steer(currentVelocity.y, steerInput.y * yawSpeed, accel.y);
        //  float steerZ = Steer(currentVelocity.z, steerInput.z * turnSpeed, accel.z);

        //  Vector3 steerForce = new Vector3(steerX, steerY, steerZ);


 


    }
    private void Update()
    { 
    }
    private void FixedUpdate()
    {

        UpdateControl();

    }
}
