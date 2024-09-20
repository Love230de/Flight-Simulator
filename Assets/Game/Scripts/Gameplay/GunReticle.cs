using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReticle : MonoBehaviour
{
    [SerializeField] private RectTransform gunReticle;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float scale;

    private void LateUpdate()
    {
        Vector3 flighDirection = (Quaternion.Inverse(rb.rotation) * rb.velocity).normalized * rb.velocity.magnitude;
        float length = flighDirection.z;
        gunReticle.anchoredPosition = new Vector3(flighDirection.x, flighDirection.y, length) * scale;
    }
}
