using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AeroBody : MonoBehaviour
{
    Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }
    [SerializeField] private float liftValue;
    [SerializeField] private AnimationCurve dragLeft, dragRight, dragForward,dragBackward, dragUp,dragDown;

    [SerializeField] private AnimationCurve liftCoef;
    [SerializeField] private AnimationCurve inducedDragCoef;
    //Stall speed and speed will be in knots later I will set this in a gameworld singleton
    [SerializeField] private float stallSpeed;
    public float AOA { get;set; }
    [SerializeField] private float inducedDragPower = 25;
    public float YawAOA {  get;set; }
    public Vector3 localVelocity {  get; set; }
    private Vector3 prevVelocity;
    private Vector3 currentVelocity;
    private Vector3 acceleration;

    public Vector3 localAngularVelocity { get; set; }

    private Vector3 drag { get; set; }

 

    public float G {  get; set; }
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
            dragRight.Evaluate(localVelocity.x), 
            dragLeft.Evaluate(localVelocity.x ), 
            dragUp.Evaluate(localVelocity.y), 
            dragDown.Evaluate(localVelocity.y ), 
            dragForward.Evaluate(localVelocity.z), 
            dragBackward.Evaluate(localVelocity.z)).magnitude;
        rb.AddRelativeForce(drag);
    
    }
    //Add speed brakes 
    private void CalculateLift(Vector3 right,float AngleOfAttack)
    {
        var liftVelocity = Vector3.ProjectOnPlane(localVelocity,right);

        var liftVelocitySquard = liftVelocity.sqrMagnitude;

        var liftCoef = this.liftCoef.Evaluate(AngleOfAttack * Mathf.Rad2Deg);

        var liftPower = liftVelocitySquard * liftCoef * liftValue;

        var liftDirection = Vector3.Cross(liftVelocity.normalized,right);

        var lift = liftDirection * liftPower;

        var dragCoef = liftCoef * liftCoef;

        var dragPower = liftVelocitySquard * dragCoef * inducedDragCoef.Evaluate(Mathf.Max(0, localVelocity.z));

        var inducedDragDirection = -liftVelocity.normalized;

        var drag = inducedDragDirection * dragPower;

        rb.AddRelativeForce(lift + drag);
    }

   
    
    private void CalculateGForce()
    {
       
       

        acceleration = ( prevVelocity- currentVelocity )/Time.deltaTime;

        float gravityScale = 9.87f;
        prevVelocity = currentVelocity;
        G = Vector3.Cross (acceleration /gravityScale,Vector3.right).magnitude;
   

    }
    private void StallBody()
    {
        float speed = currentVelocity.magnitude;
        if(speed < stallSpeed)
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
        CalculateGForce();
        ApplyDrag();
        //Testing Steering
        //CalculateSteer(Vector3.right * Input.GetAxis("Vertical") * 30.5f);
        // CalculateSteer(Vector3.forward * Input.GetAxis("Horizontal") * 45.5f);

    }
}
