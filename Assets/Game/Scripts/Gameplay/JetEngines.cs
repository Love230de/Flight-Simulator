using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JetEngines : MonoBehaviour
{
    [SerializeField] private float maxThrustOutPut = 10000;
    [SerializeField] private float totalThrust = 1000000;
    [SerializeField] private float thrustGain = 0.0f;
    private float currentThrust = 0.0f;
    private float thrustRatio = 0.0f;
    private float thrustOutput;
     private Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }

    public void AdjustThrust(float throttleAmount)
    {
        currentThrust += throttleAmount * 10;
        currentThrust = Mathf.Clamp(currentThrust, 0.0f, totalThrust);
    }

    public void RunEngines()
    {
        thrustRatio = currentThrust / totalThrust;
     
        if (thrustRatio > 0.0)
        {
            thrustOutput += thrustRatio * thrustGain * Time.deltaTime;
        }
        else if (thrustRatio < 0.0)
        {
            thrustOutput -= thrustRatio * thrustGain * Time.deltaTime;
        }
      
        Debug.Log(thrustOutput);
        thrustOutput = Mathf.Clamp(thrustOutput, 0, maxThrustOutPut);
       
    }
    private void Update()
    {
      RunEngines();
    }
    private void FixedUpdate()
    {
        Vector3 forwardThrust = Vector3.forward * thrustOutput;
        rb.AddRelativeForce(forwardThrust);
    }
}
