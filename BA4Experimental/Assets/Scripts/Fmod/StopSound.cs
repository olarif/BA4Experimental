using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    public StudioEventEmitter Target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target.Stop();
    }
}
