using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    GameObject playerFollow;
    GameObject player;
    GameMaster gm; 

    [SerializeField] float aggroRange;
    [SerializeField] float stopRange;
    //[SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float smoothDamp = 2f;
    //[SerializeField] float speed = 2f;

    private Vector2 offset = new Vector2(-2, 0);

    Rigidbody2D rb;
    Vector2 velocity;
    //[SerializeField] Vector2 offset;

    private bool following = false;

    private float distance;

    void Start()
    {
        playerFollow = GameObject.FindGameObjectWithTag("Follow");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnLevelWasLoaded(int level)
    {
        playerFollow = GameObject.FindGameObjectWithTag("Follow");
        player = GameObject.FindGameObjectWithTag("Player");

        if (following)
        {
            transform.position = gm.lastCheckpointPos + offset;
        }
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < aggroRange && distance >= stopRange)
        {
            following = true;
        }

        if (following)
        {

            //transform.parent = null;
            //DontDestroyOnLoad(gameObject);
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
            transform.position = Vector2.SmoothDamp(this.transform.position, playerFollow.transform.position, ref velocity, smoothDamp);
            //transform.position = Vector2.Lerp((Vector2)this.transform.position, playerFollow.transform.position, moveSpeed * Time.deltaTime);
            //Vector2 newVector = direction.normalized * speed;
            //rb.velocity = newVector;
        }

        if (distance < aggroRange && distance >= stopRange)
        {
            //only follow is fish is moving
            //transform.position = Vector2.Lerp((Vector2)this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards((Vector2)this.transform.position + offset, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
