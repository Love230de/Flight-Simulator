using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WorldData
{
    public float gravityScale = 1.0f;

    public float speedScale = 1.0f;

    public float measureScale = 2;
    public Vector3 ScaleGravity(Vector3 velocity)
    {
        float x = (velocity.x ) * gravityScale;
        float y = (velocity.y ) * gravityScale;
        float z = (velocity.z ) * gravityScale;
        return new Vector3(x, y, z);
    }
    public Vector3 ScaleVelocity(Vector3 velocity)
    {
        float x = (velocity.x) * speedScale;
        float y = (velocity.y) * speedScale;
        float z = (velocity.z) * speedScale;
        return new Vector3(x,y,z);
    }
}
