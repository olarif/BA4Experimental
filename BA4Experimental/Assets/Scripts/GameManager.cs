using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameMaster gm;

    private void Awake()
    {
        FMODUnity.RuntimeManager.LoadBank("Master");
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        player.transform.position = gm.lastCheckpointPos;

    }

    void Update()
    {

    }
}
