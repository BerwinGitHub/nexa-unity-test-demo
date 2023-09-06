using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>: MonoBehaviour where T:Singleton <T>
{
    private static T instance;
    public static  T getinstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<T>() as T;
            if (instance == null)
            {
                GameObject obj = new GameObject("singleton") as GameObject ;
                instance = obj.AddComponent<T>() as T;
                DontDestroyOnLoad(obj);
            }
        }
        return instance;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
