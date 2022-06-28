using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject[] fish;
    [Tooltip("Minimum distance between NPC'S")]
    [SerializeField] private float distanceMin = 0.3f;
    [Tooltip("Maximum distance between NPC'S")]
    [SerializeField] private float distanceMax = 0.7f;
    [SerializeField] private float stopDistance = 0.1f;

    GameObject playerFollow;
    GameObject player;
    [SerializeField] float aggroRange = 3.1f;
    [SerializeField] float stopRange = 1f;
    [SerializeField] float rotationSpeed = 4f;
    [SerializeField] float smoothDamp = 0.7f;

    private float distanceBetween;
    private float distance;

    //private bool following = false;

    Vector2 velocity;

    void Start()
    {
        fish = GameObject.FindGameObjectsWithTag("NPC");

        distanceBetween = Random.Range(distanceMin, distanceMax);

        playerFollow = GameObject.FindGameObjectWithTag("Follow");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Rotate();
        Separate();
        Follow();
    }

    private void Follow()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < aggroRange && distance >= stopRange)
        {
            transform.position = Vector2.SmoothDamp(this.transform.position, playerFollow.transform.position, ref velocity, smoothDamp);
        }
    }

    private void Separate()
    {
        foreach (GameObject go in fish)
        {
            if (go != gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);

                if (distance <= distanceBetween && distance > stopDistance)
                {
                    Vector3 direction = transform.position - go.transform.position;
                    direction.Normalize();

                    transform.position += direction * Time.deltaTime;
                }

            }
        }
    }

    private void Rotate()
    {
        //rotate towards player
        var offset = -90f;
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
