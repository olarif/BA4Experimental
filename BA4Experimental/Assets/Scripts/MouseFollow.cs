using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

    [SerializeField] public float currentSpeed;
    [Range(0f, 10f)] [SerializeField] public float maxSpeed = 5;
    [Range(0f, 20f)] [SerializeField] private float friction = 8f;
    [Range(0f, 1f) ] [SerializeField] private float acceleration = .2f;
    [Range(0f, 20f)] [SerializeField] private float rotationSpeed = 5f;

    private float distance;
    private Vector3 mousePos;

    public Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    public SpriteRenderer body;
    public SpriteRenderer sideFin;
    public SpriteRenderer bottomFin;
    public SpriteRenderer rareFin;

    private bool speedUp = false;
    private bool slowDown = false;

    public float slowSpeed = 0.5f;
    public float speedMultiplier = 0.2f;
   

    void Start()
    {
        
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
        if(distance < .8f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, (rotationSpeed / 2)* Time.deltaTime);
        } else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        //Flip fish when looking the to left
        if (transform.rotation.eulerAngles.z < 269 && transform.rotation.eulerAngles.z > 91)
        {
            sr.flipY = true;
            body.flipY = true;
            body.transform.localPosition = new Vector3(body.transform.localPosition.x,3.25f,body.transform.localPosition.z);
            sideFin.flipY = true;
            sideFin.transform.localPosition = new Vector3(sideFin.transform.localPosition.x, 3.14f, body.transform.localPosition.z);
            bottomFin.flipY = true;
            bottomFin.transform.localPosition = new Vector3(bottomFin.transform.localPosition.x, 3.25f, body.transform.localPosition.z);
            rareFin.flipY = true;
            rareFin.transform.localPosition=new Vector3(rareFin.transform.localPosition.x, 3.25f,rareFin.transform.localPosition.z);
        }
        else
        {
            sr.flipY = false;
            body.flipY = false;
            body.transform.localPosition = new Vector3(body.transform.localPosition.x, 0f, body.transform.localPosition.z);
            sideFin.flipY = false;
            sideFin.transform.localPosition = new Vector3(sideFin.transform.localPosition.x, 3.09f, body.transform.localPosition.z);
            bottomFin.flipY = false;
            bottomFin.transform.localPosition = new Vector3(bottomFin.transform.localPosition.x, 2.415f, body.transform.localPosition.z);
            rareFin.flipY = false;
            rareFin.transform.localPosition = new Vector3(rareFin.transform.localPosition.x, 3.24f, rareFin.transform.localPosition.z);
        }

        // timer to slow down movement

        if (slowDown)
        {
            if(maxSpeed >= slowSpeed)
            {
                maxSpeed -= speedMultiplier * Time.deltaTime;
            }
        }

        if (speedUp)
        {
            if (maxSpeed <= 2.5f)
            {
                maxSpeed += speedMultiplier * Time.deltaTime;
            }
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
        anim.SetFloat("Speed", currentSpeed);
        //Move rigidbody
        //position = Vector2.Lerp(transform.position, mousePos, moveSpeed / 10);
        //rb.MovePosition(position);
    }

    public void DecreaseMovement(float movement)
    {
        maxSpeed -= movement + Time.deltaTime;
        //maxSpeed = movement;
    }


    public void SlowDown()
    {
        slowDown = true;
        speedUp = false;
    }

    public void SpeedUp()
    {
        speedUp = true;
        slowDown = false;
    }
}
