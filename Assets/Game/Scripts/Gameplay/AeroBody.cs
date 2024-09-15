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
    [SerializeField] private float dragCoefLeft, dragCoefRight, dragCoefForward, dragCoefBackward, dragCoefUp, dragCeofDown;
    [SerializeField] private AnimationCurve dragLeft, dragRight, dragForward, dragUp,dragDown;

    [SerializeField] private AnimationCurve liftCoef;

    public float AOA { get;set; }

    public float YawAOA {  get;set; }
    private Vector3 localVelocity {  get; set; }

    private Vector3 currentAngularVelocity;
    private Vector3 prevVelocity;
    private Vector3 currentVelocity;
    private Vector3 acceleration;

    private Vector3 localAngularVelocity { get; set; }

    private Vector3 drag { get; set; }

    private Vector3 lift;

    public Vector3 G {  get; set; }
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
       drag =  localVelocity.sqrMagnitude * -localVelocity.normalized * MathUtilties.Scale6(localVelocity.normalized,dragRight.Evaluate(localVelocity.x * dragCoefRight), dragRight.Evaluate(localVelocity.x * dragCoefLeft), dragRight.Evaluate(localVelocity.y * dragCoefUp), dragRight.Evaluate(localVelocity.y * dragCeofDown), dragRight.Evaluate(localVelocity.z * dragCoefForward), dragRight.Evaluate(localVelocity.z * dragCoefBackward)).magnitude;
       rb.AddRelativeForce(drag);
    
    }
    //Add speed brakes 
    private void CalculateLift(Vector3 right,float AngleOfAttack)
    {
        Vector3 liftVelocity = Vector3.ProjectOnPlane(localVelocity, right);
        
        Vector3 liftDirection = Vector3.Cross(liftVelocity.normalized,right);

        lift = liftDirection * liftVelocity.magnitude * liftValue * liftCoef.Evaluate(AngleOfAttack * Mathf.Rad2Deg) ;
        float inducedDragPower = 6;
        Vector3 inducedDrag = -liftVelocity.normalized * liftVelocity.sqrMagnitude  * inducedDragPower;

        rb.AddRelativeForce(lift + inducedDrag);
    }

    
    private void CalculateGForce()
    {
       
       

        acceleration = ( currentVelocity - prevVelocity)/Time.deltaTime;
       
        Vector3 g = MathUtilties.Scale6(acceleration, localAngularVelocity.x, localAngularVelocity.x, localAngularVelocity.y * YawAOA, localAngularVelocity.y * YawAOA,localAngularVelocity.z,-9.88f);
        prevVelocity = currentVelocity;
        G = g;

       

    }

    //Move to Control Surfaces
    //Please Imrpove this like include a steering anim curve a lerp towards the target clamp by acceleration
    //Add ability for the jet to add a slight y axis torque when banked
    void CalculateSteer(Vector3 targetVelocity)
    {

        currentAngularVelocity = localAngularVelocity;

        Vector3 error = targetVelocity - localAngularVelocity * Mathf.Max(0, localVelocity.z);
       
      
        rb.AddRelativeTorque(error * Mathf.Deg2Rad,ForceMode.VelocityChange);
    }
    private void FixedUpdate()
    {
        CalculateAircraftState();
        ApplyDrag();
        CalculateLift(Vector3.right,AOA);
        CalculateLift(Vector3.up, YawAOA);
        CalculateGForce();
       //Testing Steering
        //CalculateSteer(Vector3.right * Input.GetAxis("Vertical") * 30.5f);
       // CalculateSteer(Vector3.forward * Input.GetAxis("Horizontal") * 45.5f);

    }
}
