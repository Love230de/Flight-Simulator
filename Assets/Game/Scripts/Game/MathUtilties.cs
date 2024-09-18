using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class MathUtilties
{
    //Vector3 Scale by 6
    public static Vector3 Scale6(
      Vector3 value,float posX, float negX,float posY, float negY,float posZ, float negZ)
    {
        Vector3 result = value;

        if (result.x > 0)
        {
            result.x *= posX;
        }
        else if (result.x < 0)
        {
            result.x *= negX;
        }

        if (result.y > 0)
        {
            result.y *= posY;
        }
        else if (result.y < 0)
        {
            result.y *= negY;
        }

        if (result.z > 0)
        {
            result.z *= posZ;
        }
        else if (result.z < 0)
        {
            result.z *= negZ;
        }

        return result;
    }
    //Local vector3 orientation by rotation
    public static Vector3 LocalVector3(Quaternion rotation,Vector3 t)
    {
        return Quaternion.Inverse(rotation) * t;
    }
    //get acceleration of vector3 velocity
    public static Vector3 GetAcceleration(ref Vector3 prevVelocity,ref Vector3 currentVelocity)
    {
        return prevVelocity - currentVelocity;
    }

    public static Vector3 ConvertToKnots(Vector3 velocity)
    {
        float x = (velocity.x * velocity.x ) * 1.852f;
        float y = (velocity.y * velocity.y) * 1.852f;
        float z = (velocity.z * velocity.z) * 1.852f;
        return new Vector3  (x, y, z);
    }

}
