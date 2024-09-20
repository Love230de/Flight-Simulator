using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private RectTransform compassElement;
    [SerializeField] private float compassOffsetSize;
    private void LateUpdate()
    {
        Vector3 forwardDirection = Vector3.ProjectOnPlane(transform.forward,Vector3.up).normalized;
        float compassOffset = (Vector3.SignedAngle(forwardDirection,Vector3.forward,Vector3.up)/180f) * compassOffsetSize;

        compassElement.anchoredPosition = new Vector2(compassOffset, 0);



        
    }
}
