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

    void Start()
    {
        fish = GameObject.FindGameObjectsWithTag("NPC");

        distanceBetween = Random.Range(distanceMin, distanceMax);
    }

    private void OnLevelWasLoaded(int level)
    {
        fish = GameObject.FindGameObjectsWithTag("NPC");
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
                    Vector3 direction = transform.position - go.transform.position;
                    direction.Normalize();

                    transform.position += direction * Time.deltaTime;
                }

            }
        }
    }
}
