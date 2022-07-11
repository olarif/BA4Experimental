using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy1 : MonoBehaviour
{
    public static DontDestroy1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
