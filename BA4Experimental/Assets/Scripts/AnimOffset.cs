using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOffset : MonoBehaviour
{
    Animator anim;
    private float offset;

    void Start()
    {
        offset = Random.Range(0f, 1f);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Cycle Offset", offset);
    }
}
