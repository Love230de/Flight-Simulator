using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform jet;

    private Vector3 offset;

    private void Start()
    {
        offset = Vector3.forward * -25;
    }
    private void Update()
    {
     
        transform.position = jet.position + (jet.rotation * offset);




        transform.rotation = jet.rotation;
    }
}
