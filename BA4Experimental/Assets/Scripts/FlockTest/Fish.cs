using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public FlockManager myManager;
    public float speed;

    void Start()
    {
        speed = Random.Range(0.15f, 1.5f);
    }

    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
        CalculateMove();
    }

    void CalculateMove()
    {
        Vector2 vectorOfCenter = Vector2.zero;
        Vector2 vectorAvoidance = Vector2.zero;

        foreach(GameObject go in myManager.allFish)
        {
            if(go != this.gameObject)
            {
                vectorOfCenter += (Vector2)go.transform.position;

                if(Vector2.Distance(go.transform.position, transform.position) < 1)
                {
                    vectorAvoidance += (Vector2)transform.position - (Vector2)go.transform.position;
                }
            }

            vectorOfCenter = vectorOfCenter / (float)(myManager.allFish.Length);
            Vector2 direction = (vectorOfCenter + vectorAvoidance) - (Vector2)transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        }
    }
}
