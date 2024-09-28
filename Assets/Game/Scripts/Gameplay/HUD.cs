using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private AeroBody body;
    [SerializeField] private ControlSurfaces controlSurfaces;

    [SerializeField] private RectTransform boreSight;

    [SerializeField] private RectTransform velocityMarker;
    
    public RectTransform fakePitch;
    public RectTransform pitchLadderTest;
    Vector3 angles = Vector3.zero;
    public Vector3 startPosition;
    private Camera main
    {
        get { return Camera.main; }
    }
    //Compass

    //PitchLadder

    //Navigation

    //Weapons
    private void Start()
    {
      
       
    }
    private void PathMarkers(Vector3 offset,RectTransform marker)
    {
        Vector3 direction = offset;
        
        marker.anchoredPosition = direction;
    }
    
    private void LateUpdate()
    {
        PathMarkers(((Camera.main.transform.localPosition ) + (body.localVelocity.normalized * body.localVelocity.magnitude)),velocityMarker);


        PathMarkers((Camera.main.transform.localPosition + body.transform.forward),boreSight);
        PathMarkers((Camera.main.transform.localPosition + body.transform.forward), fakePitch);
       
        angles.z = -body.transform.eulerAngles.z;
        angles.x = body.transform.eulerAngles.x;
        // fakePitch.anchoredPosition = new Vector3(0,(Mathf.Tan((angleX) * Mathf.Deg2Rad) / Mathf.Tan(main.fieldOfView * Mathf.Deg2Rad)/2 * main.pixelHeight * 2),0) ;
        Debug.Log(Mathf.Tan(angles.x) / Mathf.Tan(main.fieldOfView / 2 * Mathf.Deg2Rad));
        pitchLadderTest.localEulerAngles = new Vector3(0,0,angles.z);
    }
}
