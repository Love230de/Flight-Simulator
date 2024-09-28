using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform jet;
    [SerializeField] private Transform rig;
    private Vector3 offset;

    private void Start()
    {
        offset = Vector3.forward * 5;
    }
    private void Update()
    {
        Quaternion yRotation = Quaternion.AngleAxis(jet.transform.eulerAngles.y, Vector3.up);
        Quaternion zRotation = Quaternion.AngleAxis(jet.transform.eulerAngles.z, Vector3.forward);
        transform.position =   new Vector3(jet.position.x,rig.position.y,jet.position.z) +  (yRotation *offset);


    
     
        transform.rotation = yRotation * zRotation;
    }

}
