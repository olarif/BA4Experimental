using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
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
            gm.lastCheckpointPos = this.transform.position;
        }

        if (collision.CompareTag("NPC"))
        {
            fishe.Add(gameObject);
        }
    }
}
