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
    GameManager m;

    private void OnLevelWasLoaded(int level)
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //m = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        //m = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            if (this.gameObject.CompareTag("NPC"))
            {
                gm.fish.Add(this.gameObject);
                this.transform.parent = null;
                this.transform.position = gm.lastCheckpointPos + new Vector2(-10,0);
                gameObject.SetActive(false);
                health = 5;
            }

            if (this.gameObject.CompareTag("Player"))
            {
                gm.Reenable();
                this.transform.position = gm.lastCheckpointPos;
                health = 100;
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BlackSub")
		{
            if (!isHit)
            {
                health -= hitDamage;
                isHit = true;
                count = timeDifferenceForHitCount;
                Destroy(collision.gameObject);
            }
        }
    }
}
