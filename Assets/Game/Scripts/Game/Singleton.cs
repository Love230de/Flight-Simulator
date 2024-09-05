using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    //Just a simple singleton pattern.

    private static T instance;

    public static T Instance {  get { return instance; } }


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null && instance != this)
        {
           
            
        }
       else 
       {
            instance = gameObject.GetComponent<T>();
            
       }
    }

}
