using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health=100;
    public float hitDamage = .5f;
    float count;
    bool isHit=false;
    public float timeDifferenceForHitCount = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) 
        {
            count -= Time.deltaTime;
            if (count <= 0) isHit = false;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isHit)
        {
            if (collision.gameObject.tag == "BlackSub")
            {
                health -= hitDamage;
                isHit = true;
                count = timeDifferenceForHitCount;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!isHit)
        {
            
                health -= hitDamage;
                isHit = true;
                count = timeDifferenceForHitCount;
            
        }
    }
}
