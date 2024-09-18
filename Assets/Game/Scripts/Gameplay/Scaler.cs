using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Scaler : MonoBehaviour
{
   private AeroBody aeroBody
    {
        get { return GetComponent<AeroBody>(); }
    }

   private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }

    public void Update()
    {
        rb.velocity = GameManager.gameManager.WorldData.ScaleVelocity(rb.velocity);
        aeroBody.G = aeroBody.G * GameManager.gameManager.WorldData.gravityScale;
        //Physics.gravity = GameManager.gameManager.WorldData.ScaleGravity(Vector3.down);
    }
}
