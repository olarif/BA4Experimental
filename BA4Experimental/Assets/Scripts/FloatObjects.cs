using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObjects : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        FloatHorizontal();
    }

    void FloatHorizontal()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

}
