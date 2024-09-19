using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jet : MonoBehaviour
{
    /*
     * Jet class holds all aerodynamic and performance data for jet.
     * This will be serialized class. When I begin work on the AI I will either use json or scriptable objects to make this easier on me.
     * Instead of writing a new jet I can just set the paremeters in a file or scriptable object
     */

    [SerializeField] private string name;
    [SerializeField] private float liftValue;
    [SerializeField] private AnimationCurve dragLeft, dragRight, dragForward, dragBackward, dragUp, dragDown;
    [SerializeField] private AnimationCurve liftCoef;
    [SerializeField] private AnimationCurve inducedDragCoef;
    [SerializeField] private float stallSpeed;
    [SerializeField] private float inducedDragPower = 25;

    [SerializeField] private AnimationCurve steerCoef, pitchCoef;
    [SerializeField] private Vector3 turnAcceleration;
    [SerializeField] private float maxThrust;
    [SerializeField] private float throttleIncSpeed;
    [SerializeField] private Vector3 turnSpeed;
    public string Name { get => name; set => name = value; }
    public float LiftValue { get => liftValue; set => liftValue = value; }
    public AnimationCurve DragLeft { get => dragLeft; set => dragLeft = value; }
    public AnimationCurve DragRight { get => dragRight; set => dragRight = value; }
    public AnimationCurve DragForward { get => dragForward; set => dragForward = value; }
    public AnimationCurve DragBackward { get => dragBackward; set => dragBackward = value; }
    public AnimationCurve DragUp { get => dragUp; set => dragUp = value; }
    public AnimationCurve DragDown { get => dragDown; set => dragDown = value; }
    public AnimationCurve LiftCoef { get => liftCoef; set => liftCoef = value; }
    public AnimationCurve InducedDragCoef { get => inducedDragCoef; set => inducedDragCoef = value; }
    public float StallSpeed { get => stallSpeed; set => stallSpeed = value; }
    public float InducedDragPower { get => inducedDragPower; set => inducedDragPower = value; }
    public AnimationCurve SteerCoef { get => steerCoef; set => steerCoef = value; }
    public AnimationCurve PitchCoef { get => pitchCoef; set => pitchCoef = value; }
    public Vector3 TurnAcceleration { get => turnAcceleration; set => turnAcceleration = value; }
    public float MaxThrust { get => maxThrust; set => maxThrust = value; }
    public float ThrottleIncSpeed { get => throttleIncSpeed; set => throttleIncSpeed = value; }
    public Vector3 TurnSpeed { get => turnSpeed; set => turnSpeed = value; }
}
