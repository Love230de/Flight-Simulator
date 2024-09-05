using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour 
{
    //Shitty Input stuff
    public static PlayerInputHandler Instance { get; private set; }
    [SerializeField] private InputActionAsset inputActions;
    #region Throttle
    private float throttle;

    private bool throttleIncrease;
    private bool throttleDecrease;

    public bool ThrottleIncrease { get => throttleIncrease; set => throttleIncrease = value; }
    public bool ThrottleDecrease { get => throttleDecrease; set => throttleDecrease = value; }
    public float Throttle { get => throttle; set => throttle = value; }
    #endregion

    private void Awake()
    {
        if(inputActions == null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void RegisterInput()
    {
       Throttle += inputActions.FindActionMap("JetControls").FindAction("ThrottleUp").ReadValue<float>();

    }
    private void DeRegisterInput()
    {
        Throttle -= inputActions.FindActionMap("JetControls").FindAction("ThrottleUp").ReadValue<float>();
    }

    private void Update()
    {
        throttleIncrease = Mathf.Approximately(Throttle,0);
        throttleDecrease = Mathf.Approximately(throttle,1);
    }

    private void OnDisable()
    {
        RegisterInput();
    }

    private void OnEnable()
    {
       
        DeRegisterInput();
    }

}
