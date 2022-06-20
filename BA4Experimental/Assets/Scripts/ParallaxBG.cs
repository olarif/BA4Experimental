using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public float length, startPos;
    public Transform cameraTransform;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = cameraTransform.position.x * (1 - parallaxEffect);
        float distance = cameraTransform.transform.position.x * parallaxEffect;
        
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
