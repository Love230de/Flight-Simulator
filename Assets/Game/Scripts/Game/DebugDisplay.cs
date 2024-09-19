using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    [SerializeField] private AeroBody body;
    
    private float GForce;

    private float angularSpeed;

    private float AOA;

    private float YawAOA;

    private float speedKTS;
    private void Update()
    {
        GForce = Mathf.Clamp(body.G.magnitude,-15,15);
        
        angularSpeed = body.localAngularVelocity.magnitude;
        AOA = body.AOA * Mathf.Rad2Deg;
        YawAOA = body.YawAOA * Mathf.Rad2Deg;
        speedKTS = (body.localVelocity.z) * GameManager.gameManager.WorldData.measureScale;
    }
    private void OnGUI()
    {
        string Debug = "Gforce " + GForce.ToString() + "\n" + "angular speed " + angularSpeed.ToString() + "\n" + "PitchAngleOfAttack " + AOA.ToString() + "\n" + "YAW Angle Of Attack " + YawAOA.ToString() + "\n" + "Speed in Knots " + speedKTS.ToString() + "\n";
        GUI.Label(new Rect(25, 25, 500, 500), Debug);
    }

}
