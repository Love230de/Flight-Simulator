using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchHorizon : MonoBehaviour
{
    [SerializeField] private AeroBody body;
    [SerializeField] private RectTransform rect;
    [SerializeField] private float offsetY;

    private void Start()
    { 
    
    }
    private void Update()
    {
    
        
        //pitchOffset = Mathf.Tan( Mathf.Deg2Rad * (body.transform.eulerAngles.x/180f)) / Mathf.Tan(main.fieldOfView * Mathf.Deg2Rad) / 2 * main.pixelHeight * 2;

        
        Quaternion localRotation =  Quaternion.AngleAxis(-body.transform.eulerAngles.z,Vector3.forward);

       
        //pos.y = Mathf.Clamp(pos.y, limitY1,limitY);
        //float angle = Vector3.Angle(pos,body.transform.forward);
        rect.transform.localRotation= localRotation;
        //rect.anchoredPosition3D = pos;
       // float posY = Mathf.Abs( Mathf.Tan(angle * Mathf.Deg2Rad)/main.fieldOfView * main.pixelHeight * 2);
        //float newPosY = rect.anchoredPosition3D.y;

     
  
      

        //Debug.Log(dimensions);
    }
}
