using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public string soundToPlay;

    FMOD.Studio.EventInstance Sound;

    private void Start()
    {
        Sound = FMODUnity.RuntimeManager.CreateInstance(soundToPlay);
    }

    void PlaySoundFmod(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sound.start();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Sound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
