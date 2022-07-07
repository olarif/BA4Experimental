using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMovement : MonoBehaviour
{
    public float speed = 1f;
    public bool hasBoundary = false;
    public ParticleSystem particle;
    public float maxLifeTime = 15;
    public float minLifeTime = 3;
    public float speedUpDistance = 9;
    public BoxCollider2D backCollider;
    public bool startFollow = false;

    private void Start()
    {
        hasBoundary = false;
        startFollow = false;
        particle.Stop();
        particle.startLifetime = minLifeTime;  
        particle.Play();
        if (backCollider != null) backCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (hasBoundary)
        {
            particle.startLifetime = maxLifeTime;
            if (backCollider != null) backCollider.enabled = true;        
            
        }
        else
        {
            if (startFollow)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                float currentSpeed;
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < speedUpDistance)
                {
                    currentSpeed = speed;
                }
                else
                {
                    currentSpeed = (distance - speedUpDistance) * 1.3f + speed;
                }
                if (player.transform.position.x > this.transform.position.x)
                {
                    transform.position += Vector3.right * currentSpeed * Time.deltaTime;
                }
                else if (player.transform.position.x < this.transform.position.x)
                {
                    transform.position -= Vector3.right * currentSpeed * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "LevelEnd") hasBoundary = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LevelEnd") hasBoundary = true;
    }

    public void StartParticle() 
    {
        particle.Play();
        startFollow = true;
    }

    public void StopParticle()
    {
        particle.Stop();
        startFollow = false;
    }
}
