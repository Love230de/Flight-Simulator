using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPathMarker : MonoBehaviour
{
    [SerializeField] private AeroBody body;
    private Vector3 forward;
    private void Start()
    {
        forward =  body.transform.position + body.transform.forward;
    }
    private void FixedUpdate()
    {
        Vector3 target = (body.localVelocity.normalized);
        target.y =  body.localVelocity.x * body.localVelocity.y;
        target.x = body.localVelocity.x;
        target.Normalize();
        
        transform.position = body.transform.rotation * body.transform.position + (forward + (target));
    }
}
