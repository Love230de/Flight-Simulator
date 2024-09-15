using UnityEditor.PackageManager;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Plane : MonoBehaviour
{
    //I guess were going to use rigidbody turn into a plane class that can be accessed by player or bot controller
    private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }
    
    #region Velocities
    private Vector3 Velocity;
    private Vector3 localVelocity;
    private Vector3 prevLocalVelocity;
    public Vector3 Velocity1 { get => Velocity; set => Velocity = value; }
    public Vector3 LocalVelocity { get => localVelocity; set => localVelocity = value; }
    private float AOA;
    #endregion

    #region Drag
    private Vector3 InducedDrag;
    public Vector3 InducedDrag1 { get => InducedDrag; set => InducedDrag = value; }
    [SerializeField] private AnimationCurve dragUpCoef;
    [SerializeField] private AnimationCurve dragDownCoef;
    [SerializeField] private AnimationCurve dragLeftCoef;
    [SerializeField] private AnimationCurve dragRightCoef;
    [SerializeField] private AnimationCurve dragForwardCoef;
    [SerializeField] private AnimationCurve dragBackwardCoef;

    [SerializeField] private float dragUpPower;
    [SerializeField] private float dragDownPower;
    [SerializeField] private float dragLeftPower;
    [SerializeField] private float dragRightPower;
    [SerializeField] private float dragForwardPower;
    [SerializeField] private float dragBackwardPower;
    [SerializeField] private float liftDragPower;
    #endregion

    #region Lift
    [SerializeField] private AnimationCurve liftCoef;
    [SerializeField] private float liftPower;
    private Vector3 lift;

    public Vector3 Lift { get => lift; set => lift = value; }

    #endregion

    //Align rotation with velocity
    private Vector3 CalculateAcceleration()
    {
        var acceleration = prevLocalVelocity - localVelocity;
        prevLocalVelocity = localVelocity;

        return acceleration * Time.deltaTime;
    }

    private float CalculateSteering(float accel,float velocity,float targetValue)
    {

         var error = velocity - targetValue;

        return Mathf.Clamp(error, -accel, accel);

    }

 
    private void ApplyDrag()
    {
        var localV = localVelocity;
        var localVelocitySquared = localV.sqrMagnitude;
        var dragBackward =  dragBackwardCoef.Evaluate(Mathf.Abs(localV.z)) * dragBackwardPower;
        var dragForward =  dragRightCoef.Evaluate(Mathf.Abs(localV.z)) * dragForwardPower;
        var dragUp =     dragUpCoef.Evaluate(Mathf.Abs( localV.y)) * dragUpPower; 
        var dragDown =  dragUpCoef.Evaluate(Mathf.Abs(localV.y)) * dragDownPower; 
        var dragRight =  dragRightCoef.Evaluate(Mathf.Abs(localV.x)) * dragRightPower; 
        var dragLeft = dragLeftCoef.Evaluate(Mathf.Abs(localV.x)) * dragLeftPower; 
        var dragCoef = MathUtilties.Scale6(localV.normalized,dragRight,dragLeft,dragDown,dragUp,dragForward, dragBackward);
        var drag = dragCoef.magnitude * localVelocitySquared * -localV.normalized;
        rb.AddRelativeForce(drag);
    }
    private void ApplyLift()
    {
        Vector3 velocityDirection = Vector3.ProjectOnPlane(localVelocity.normalized, Vector3.right);
        Vector3 liftVelocity = Vector3.Cross(velocityDirection.normalized, Vector3.right);
        float liftVelocitySquared = liftVelocity.sqrMagnitude;
        var coef = liftCoef.Evaluate(AOA * Mathf.Rad2Deg) * liftPower;
        var liftForce = liftVelocity.normalized * liftVelocitySquared * coef;
        var liftDrag = liftVelocitySquared * liftDragPower;

      

        var liftDragForce = -liftForce.normalized * liftDrag;
        rb.AddRelativeForce(liftForce + liftDragForce);
    }




    //Calculate Plane Velocities based on rotation
    private void CalculateVelocities()
    {
        Velocity = rb.velocity;
        localVelocity = MathUtilties.LocalVector3(rb.rotation, Velocity);
        AOA = Mathf.Atan2(-localVelocity.y, localVelocity.z);

    }

    private void FixedUpdate()
    {

    
        CalculateVelocities();
        ApplyLift();
        ApplyDrag();
        
       
    }
}
