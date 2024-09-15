using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform offset;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float angle = rb.angularVelocity.x - offset.eulerAngles.x;
        transform.eulerAngles = new Vector3( 15,angle,0);
    }
}
