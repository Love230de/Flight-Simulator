using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boresight : MonoBehaviour
{
    [SerializeField] private AeroBody body;
    
    private void FixedUpdate()
    {
        body.transform.position = body.transform.position + body.transform.forward;
    }
}
