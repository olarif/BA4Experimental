using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private FMODUnity.StudioEventEmitter emitter;
    float health;

    void Start()
    {
        health = GetComponent<Health>().health;
    }

    private void Update()
    {
        health = GetComponent<Health>().health;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Health", health);
    }

}
