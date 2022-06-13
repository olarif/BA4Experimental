using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    GameObject player;
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < aggroRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
