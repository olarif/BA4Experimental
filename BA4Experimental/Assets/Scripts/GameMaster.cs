using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    [HideInInspector] public List<GameObject> fish;

    public Vector2 lastCheckpointPos;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void Reenable()
    {
        foreach(GameObject fish in fish)
        {
            fish.SetActive(true);
        }
    }


}
