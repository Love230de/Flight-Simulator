using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AeroBody : MonoBehaviour
{
    Jet jet
    {
        get { return GetComponent<Jet>(); }
    }
    Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }
 
    public float AOA { get;set; }
 
    public float YawAOA {  get;set; }
    public Vector3 localVelocity {  get; set; }
    private Vector3 prevVelocity;
    private Vector3 currentVelocity;
    private Vector3 acceleration;

    public Vector3 localAngularVelocity { get; set; }

    private Vector3 drag { get; set; }

 

    public Vector3 G;
    private void CalculateAircraftState()
    {
        localVelocity =  Quaternion.Inverse(rb.rotation) *rb.velocity;
        localAngularVelocity = Quaternion.Inverse(rb.rotation) * rb.angularVelocity;
        AOA = Mathf.Atan2(-localVelocity.y, localVelocity.z);
        YawAOA = Mathf.Atan2(localVelocity.x, localVelocity.z);
        currentVelocity = rb.velocity;
        
    }

    private void ApplyDrag()
    {
        drag = localVelocity.sqrMagnitude * -localVelocity.normalized * 
            MathUtilties.Scale6(localVelocity.normalized,
              jet.DragRight.Evaluate(localVelocity.x), 
            jet.DragLeft.Evaluate(localVelocity.x ), 
            jet.DragUp.Evaluate(localVelocity.y), 
            jet.DragDown.Evaluate(localVelocity.y ), 
            jet.DragForward.Evaluate(localVelocity.z), 
            jet.DragBackward.Evaluate(localVelocity.z)).magnitude;
        rb.AddRelativeForce(drag);
    
    }
    //Add speed brakes 
    private void CalculateLift(Vector3 right,float AngleOfAttack)
    {
        var liftVelocity = Vector3.ProjectOnPlane(localVelocity,right);

        var liftVelocitySquard = liftVelocity.sqrMagnitude;

        var liftCoef = this.jet.LiftCoef.Evaluate(AngleOfAttack * Mathf.Rad2Deg);

        var liftPower = liftVelocitySquard * liftCoef * jet.LiftValue;

        var liftDirection = Vector3.Cross(liftVelocity.normalized,right);

        var lift = liftDirection * liftPower;

        var dragCoef = liftCoef * liftCoef;

        var dragPower = liftVelocitySquard * dragCoef * jet.InducedDragCoef.Evaluate(Mathf.Max(0, localVelocity.z));

        var inducedDragDirection = -liftVelocity.normalized;

        var drag = inducedDragDirection * dragPower;

        rb.AddRelativeForce(lift + drag);
    }

   
    
    public Vector3 CalculateGForce()
    {
       
       

        acceleration = (currentVelocity - prevVelocity ) /9.87f ;


        Vector3 g = MathUtilties.Scale6(acceleration.normalized, localAngularVelocity.x, localAngularVelocity.x, localAngularVelocity.y * YawAOA, localAngularVelocity.y * YawAOA, localAngularVelocity.z, -9.88f);
        prevVelocity = currentVelocity;
      
      
        return g;

       
    }
    private void StallBody()
    {
        float speed = currentVelocity.magnitude;
        if(speed < jet.StallSpeed)
        {
            Vector3 heading = (transform.position - ( currentVelocity.normalized));
            Quaternion lookRotation = Quaternion.FromToRotation(currentVelocity,heading);
            rb.MoveRotation(Quaternion.Slerp(rb.transform.rotation, lookRotation,Time.deltaTime));
        }
    }

    //Move to Control Surfaces
    //Please Imrpove this like include a steering anim curve a lerp towards the target clamp by acceleration
    //Add ability for the jet to add a slight y axis torque when banked
    private void FixedUpdate()
    {
        CalculateAircraftState();
     
        CalculateLift(Vector3.right,AOA);
        CalculateLift(Vector3.up, YawAOA);
        //StallBody();
       
        ApplyDrag();
        //Testing Steering
        //CalculateSteer(Vector3.right * Input.GetAxis("Vertical") * 30.5f);
        // CalculateSteer(Vector3.forward * Input.GetAxis("Horizontal") * 45.5f);

    }
}
