using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    GameObject playerFollow;
    GameObject player;
    [SerializeField] float aggroRange;
    [SerializeField] float stopRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed = 2f;
    //[SerializeField] Vector2 offset;

    private bool following = false;

    private float distance;

    void Start()
    {
        playerFollow = GameObject.FindGameObjectWithTag("Follow");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(playerFollow.transform.position, transform.position);

        if (distance < aggroRange && distance >= stopRange)
        {
            following = true;
        }
    }

    private void FixedUpdate()
    {
        if (following)
        {
            //rotate towards player
            var offset = -90f;
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            //move towards tail of fish
            transform.position = Vector2.Lerp((Vector2)this.transform.position, playerFollow.transform.position, moveSpeed * Time.deltaTime);
        }

        if (distance < aggroRange && distance >= stopRange)
        {
            //only follow is fish is moving
            //transform.position = Vector2.Lerp((Vector2)this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards((Vector2)this.transform.position + offset, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
