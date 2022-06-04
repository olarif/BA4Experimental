using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float friction = 8f;
    [SerializeField] private float acceleration = .2f;
    [SerializeField] private float rotationSpeed = 5f;

    private float distance;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    //private Vector2 position = new Vector2(0, 0);

    //[SerializeField] private float moveSpeed = 10f;

    void Start()
    {
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
    }


    private void FixedUpdate()
    {
        if(distance < 0.3f)
        {
            if(speed > 0)
            speed -= friction * Time.deltaTime;
        }

        //If holding down mouse button
        if (Input.GetMouseButton(0)){
            
            if(speed < maxSpeed){
                speed += maxSpeed * acceleration * Time.deltaTime;
            } else{
                speed = maxSpeed;
            }

        } else
        {
            if(speed > 0){
                speed -= friction * Time.deltaTime;
            } else{
                speed = 0;
            }

            //Decelerate
            //rb.velocity = rb.velocity * deceleration * Time.deltaTime;
        }

        if(speed > 0){
            rb.MovePosition(Vector2.MoveTowards(rb.position, mousePos, Time.deltaTime * speed));
        }

        //Move rigidbody
        //position = Vector2.Lerp(transform.position, mousePos, moveSpeed / 10);
        //rb.MovePosition(position);
    }
}
