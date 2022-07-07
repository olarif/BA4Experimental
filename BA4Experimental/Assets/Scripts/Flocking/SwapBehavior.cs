using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBehavior : MonoBehaviour
{
    GameObject player;

    public FlockBehavior followBehavior;

    private float distance;
    public float aggroDistance = 5f;

    [HideInInspector] public bool following = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > aggroDistance) return;

        if (distance < aggroDistance && !following)
        {
            //player.GetComponent<SeparateNPC>().fishList.Add(this.gameObject);
            following = true;
            GetComponentInParent<Flock>().behavior = followBehavior;
        }
    }
}
