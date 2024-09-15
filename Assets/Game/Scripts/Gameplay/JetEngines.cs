using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JetEngines : MonoBehaviour
{
    //Move to a plane class
    [SerializeField] private float maxThrust;
    [SerializeField] private float thrustGain;
    private float throttleAmount;
    [SerializeField] private Rigidbody rb;
    public void ApplyThrust(float throttle)
    {

        if (throttle > 0.0f)
        {
            throttleAmount += thrustGain;
        }
        else if (throttle < 0.0f)
        {
            throttleAmount -= thrustGain;
        }
        throttleAmount = Mathf.Clamp(throttleAmount, 0.0f, maxThrust);
        float totalThrust = (throttleAmount / maxThrust);
        var thrust =  maxThrust * Vector3.forward;
        rb.AddRelativeForce(thrust);
      //  rb.velocity = transform.forward * maxThrust;
    }
    private void FixedUpdate()
    {
        ApplyThrust(1);
    }
}
