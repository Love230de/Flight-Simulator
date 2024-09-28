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
        return  Mathf.Clamp(error, -accel, accel);
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
        var targetVelocity = Vector3.Scale(controlInput, jet.TurnSpeed * steerPower);
        var correction = new Vector3(CalculateSteer(targetVelocity.x, localAngularVelocity.x, jet.TurnAcceleration.x),
            CalculateSteer(targetVelocity.y, localAngularVelocity.y, jet.TurnAcceleration.y),
            CalculateSteer(targetVelocity.z, localAngularVelocity.z, jet.TurnAcceleration.z));

        if (speed < jet.StallSpeed && speed > jet.StallSpeed * 0.5f)
        {

            
            rb.AddRelativeTorque(correction * steerPower * 0.5f, ForceMode.VelocityChange);
        }
       
            rb.AddRelativeTorque(correction * steerPower, ForceMode.VelocityChange);
        
   
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
   
    
}
