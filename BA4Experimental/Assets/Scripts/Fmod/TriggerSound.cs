using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    FMODUnity.StudioEventEmitter gameMusic;
    public string parameter;

    private void Awake()
    {
        gameMusic = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MusicTrigger"))
        {
            if (parameter == null) return;

            MusicSection musicSection = collision.gameObject.GetComponent<MusicSection>();

            gameMusic.SetParameter(parameter, musicSection.section);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
