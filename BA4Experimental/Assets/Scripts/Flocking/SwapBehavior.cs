using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBehavior : MonoBehaviour
{
    GameObject playerFollow;
    GameObject player;

    public FlockBehavior followBehavior;

    private float distance;
    public float aggroDistance = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < aggroDistance)
        {
            GetComponentInParent<Flock>().behavior = followBehavior;
        }
    }
}
