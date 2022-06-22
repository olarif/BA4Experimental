using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numberOfFish;
    public GameObject[] allFish;
    public float rotationSpeed = 5f;

    void Start()
    {
        allFish = new GameObject[numberOfFish];

        for(int i = 0; i < numberOfFish; i++)
        {
            allFish[i] = GameObject.Instantiate(fishPrefab);
            allFish[i].transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            allFish[i].GetComponent<Fish>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
