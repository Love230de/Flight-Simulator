using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputHandler : MonoBehaviour 
{
   
    [SerializeField] private InputActionAsset inputActions;
    private InputActionMap JetControls;
    private InputAction throttleAction;
    #region Throttle
    
    private float throttle;



    #endregion


    private void Start()
    {
        JetControls = inputActions.FindActionMap("JetControls");
        JetControls.Enable();
        throttleAction = JetControls.FindAction("ThrottleAxis");
    }



    private void Update()
    {
       
    }

 
   
}
