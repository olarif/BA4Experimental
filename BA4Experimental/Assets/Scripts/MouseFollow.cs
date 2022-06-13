using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

    [SerializeField] public float currentSpeed;
    [Range(0f, 10f)] [SerializeField] private float maxSpeed = 5;
    [Range(0f, 20f)] [SerializeField] private float friction = 8f;
    [Range(0f, 1f) ] [SerializeField] private float acceleration = .2f;
    [Range(0f, 20f)] [SerializeField] private float rotationSpeed = 5f;

    private float distance;
    private Vector3 mousePos;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Get screen mouse position
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //calculate distance to cursor
        distance = Vector2.Distance(transform.position, mousePos);

        //rotate fishe
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //slow down rotation speed while close to cursor
        if(distance < 0.3f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, (rotationSpeed / 2) * Time.deltaTime);
        } else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        //Flip fish when looking the to left
        if (transform.rotation.eulerAngles.z < 270 && transform.rotation.eulerAngles.z > 90)
        {
            sr.flipY = true;
        } else
        {
            sr.flipY = false;
        }
    }


    private void FixedUpdate()
    {
        if(distance < 0.3f)
        {
            if(currentSpeed > 0)
            currentSpeed -= friction * Time.deltaTime;
        }

        //If holding down mouse button
        if (Input.GetMouseButton(0)){
            
            if(currentSpeed < maxSpeed){
                currentSpeed += maxSpeed * acceleration * Time.deltaTime;
            } else{
                currentSpeed = maxSpeed;
            }

        } else
        {
            if(currentSpeed > 0){
                currentSpeed -= friction * Time.deltaTime;
            } else{
                currentSpeed = 0;
            }

            //Decelerate
            //rb.velocity = rb.velocity * deceleration * Time.deltaTime;
        }

        if(currentSpeed > 0){
            rb.MovePosition(Vector2.MoveTowards(rb.position, mousePos, Time.deltaTime * currentSpeed));
        }

        //Move rigidbody
        //position = Vector2.Lerp(transform.position, mousePos, moveSpeed / 10);
        //rb.MovePosition(position);
    }
}
