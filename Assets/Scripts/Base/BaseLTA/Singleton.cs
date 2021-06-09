using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
            }
            return instance;
        }
    }
}
