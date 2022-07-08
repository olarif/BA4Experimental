using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public float hitDamage = .5f;
    float count;
    bool isHit = false;
    public float timeDifferenceForHitCount = .5f;

    GameMaster gm;

    private void OnLevelWasLoaded(int level)
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void Update()
    {
        if (isHit) 
        {
            count -= Time.deltaTime;
            if (count <= 0) isHit = false;
        }

        if(health <= 0)
        {
            if (this.gameObject.CompareTag("Player"))
            {
                this.transform.position = gm.lastCheckpointPos;
                health = 100;
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
