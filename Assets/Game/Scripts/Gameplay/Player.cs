using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /*
     * Eventually will add more robust controls using the new input system but for now will use the keyboard
     * 
     */
    [SerializeField] private InputActionAsset playerInput;
    private InputActionMap jetControls;
    private InputActionMap jetWeapons;
    private InputAction throttle;
    private InputAction pitch;
    private InputAction roll;
    private InputAction yaw;

    [SerializeField] private JetEngines engines;

    [SerializeField] private ControlSurfaces flightControls;


    private float inputT;

    [SerializeField] private float throttleSpeed;


    private float pitchUp;
    private float rollUp;
    private float yawUp;
    


    private void AdjustThrottle()
    {
     

        inputT = throttle.ReadValue<float>();
        
        
        //engines percentage 
        engines.ApplyThrust(inputT);
    
    }
    private void ControlSurfaces()
    {
        flightControls.UpdateSteer(new Vector3(pitchUp, yawUp, rollUp));
    }
    private void Start()
    {
       
        playerInput.Enable();
        jetControls = playerInput.FindActionMap("JetControls");
        throttle = jetControls.FindAction("ThrottleAxis");
        pitch = jetControls.FindAction("PitchAxis");
        yaw = jetControls.FindAction("YawAxis");
        roll = jetControls.FindAction("RollAxis");
    }

    private void Update()
    {
        pitchUp = pitch.ReadValue<float>();
        rollUp = roll.ReadValue<float>();
        yawUp = yaw.ReadValue<float>();
        
        AdjustThrottle();
       

    }
    private void FixedUpdate()
    {
        ControlSurfaces();
    }
}
