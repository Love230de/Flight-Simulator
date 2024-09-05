using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetController : MonoBehaviour
{
    //Do I even need a "Jet Controller"?
    private JetEngines JetEngines
    {
        get 
        {
            return GetComponent<JetEngines>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerInputHandler.Instance.ThrottleIncrease);
        JetEngines.AdjustThrust(Input.GetAxis("Vertical"));
    }
}
