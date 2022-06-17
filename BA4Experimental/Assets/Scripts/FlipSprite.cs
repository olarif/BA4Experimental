using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.rotation.eulerAngles.z < 269 && transform.rotation.eulerAngles.z > 91)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }
    }
}
