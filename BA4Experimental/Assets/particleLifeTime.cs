using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleLifeTime : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void SetToZero()
    {


        var main = ps.main;
        //main.startLifetime = 0;

        //main.duration = 0;

        ps.Stop();
    }

    void Update()
    {
        
    }
}
