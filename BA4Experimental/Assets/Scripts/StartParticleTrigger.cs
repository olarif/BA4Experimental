using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticleTrigger : MonoBehaviour
{
    public BlackMovement followParticle;
    public ParticleSystem throwParticle;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            if (followParticle != null)
            {
                followParticle.StartParticle();
                //Destroy(gameObject);

            }
            if (throwParticle != null) 
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Track/Sounds/breath");
                throwParticle.Play();
                //Destroy(gameObject);
            }
        }
    }
}
