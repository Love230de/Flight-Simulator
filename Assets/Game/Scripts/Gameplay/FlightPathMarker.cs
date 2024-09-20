using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPathMarker : MonoBehaviour
{
    [SerializeField] private RectTransform marker;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float scale;
    private Vector3 prevPosition;
    private void LateUpdate()
    {
        Vector3 flighDirection = (prevPosition + rb.velocity).normalized * rb.velocity.magnitude;
        float length = flighDirection.z;
        marker.anchoredPosition = new Vector3(flighDirection.x, flighDirection.y, length) * scale;
        prevPosition = rb.position;
    }
}
