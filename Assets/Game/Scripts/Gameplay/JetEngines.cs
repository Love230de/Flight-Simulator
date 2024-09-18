using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JetEngines : MonoBehaviour
{
    //Move to a plane class
    [SerializeField] private float maxThrust;
    [SerializeField] private Rigidbody rb;
    public void ApplyThrust(float throttle)
    {

     
        var thrust =  throttle *  maxThrust * Vector3.forward;
        rb.AddRelativeForce(thrust);

        Debug.Log(thrust);
        
        //  rb.velocity = transform.forward * maxThrust;
    }
  
}
