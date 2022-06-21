using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{
    GameObject[] fish;
    [SerializeField] private float distanceMin = 0f;
    [SerializeField] private float distanceMax = 1.5f;
    [SerializeField] private float stopDistance = 0.5f;
    private float distanceBetween;

    private Vector3 offset;

    void Start()
    {
        fish = GameObject.FindGameObjectsWithTag("NPC");

        offset = new Vector3(Random.Range(0f, 0.1f), Random.Range(0f, 0.1f), 0);

        distanceBetween = Random.Range(distanceMin, distanceMax);
    }

    void Update()
    {
        foreach(GameObject go in fish)
        {
            if(go != gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);

                if(distance <= distanceBetween && distance > stopDistance)
                {
                    //transform.position = Vector2.MoveTowards(transform.position, go.transform.position, speed * Time.deltaTime);
                    
                    Vector3 direction = transform.position - go.transform.position;
                    direction.Normalize();


                    transform.position += direction * Time.deltaTime;
                    //transform.Translate(direction * Time.deltaTime);
                }

            }
        }
    }
}
