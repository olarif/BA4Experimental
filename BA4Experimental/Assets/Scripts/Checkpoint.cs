using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector2 offset = new Vector2(-2, 0);

    private GameMaster gm;

    [HideInInspector] public List<GameObject> fishe = new List<GameObject>();

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnLevelWasLoaded(int level)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().health = 100;
            gm.lastCheckpointPos = this.transform.position;
        }

        if (collision.CompareTag("NPC"))
        {
            transform.position = gm.lastCheckpointPos + offset;
            fishe.Add(gameObject);
        }
    }
}
