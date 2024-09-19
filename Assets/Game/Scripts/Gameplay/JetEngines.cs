using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JetEngines : MonoBehaviour
{
    Jet jet
    {
        get { return GetComponent<Jet>(); }
    }
    //Move to a plane class
    [SerializeField] private Rigidbody rb;
    private float targetThrottle;
    private float totalThrottle;
    public void ApplyThrust(float input)
    {

        if (input > 0.0f && targetThrottle < 1.0f)
        {
            targetThrottle += 0.01f;
        }
        else if(input < 0.0f && targetThrottle > 0.0f)
        {
            targetThrottle -= 0.01f;
        }


        totalThrottle = Mathf.MoveTowards(totalThrottle,targetThrottle, jet.ThrottleIncSpeed * Time.deltaTime);
     
        var thrust =  totalThrottle *  jet.MaxThrust * Vector3.forward;
        rb.AddRelativeForce(thrust);

       
        
        //  rb.velocity = transform.forward * maxThrust;
    }
    private void Start()
    {
        targetThrottle = 1.0f;
    }

}
