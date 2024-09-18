using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     * Eventually will add more robust controls using the new input system but for now will use the keyboard
     * 
     */
    [SerializeField] private JetEngines engines;

    [SerializeField] private ControlSurfaces flightControls;


    private float targetThrottle;

    [SerializeField] private float throttleSpeed;

    private float currentThrottle;

    private void AdjustThrottle()
    {
        float max = 1.0f;

        if(Input.GetKey(KeyCode.LeftShift) && targetThrottle < max )
        {
            targetThrottle += 0.05f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && targetThrottle > 0f)
        {
            targetThrottle -= 0.05f * Time.deltaTime;
        }
       

        currentThrottle = Mathf.MoveTowards(currentThrottle,targetThrottle,throttleSpeed);
        //engines percentage 
        engines.ApplyThrust(currentThrottle);
    
    }

    private void Start()
    {
        currentThrottle = 0.75f;
    }

    private void Update()
    {
        AdjustThrottle();

    }

}
