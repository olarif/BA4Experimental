using UnityEngine;
using FMODUnity;

public class playSound : MonoBehaviour
{
    [HideInInspector] public EventReference EventReference;

    public void PlaySound(string sound)
    {
        var audioEvent = RuntimeManager.CreateInstance(sound);
        audioEvent.start();
    }

}
