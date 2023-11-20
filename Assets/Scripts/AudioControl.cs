using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private string soundEffect;
    FMOD.Studio.EventInstance eventInstanceRef;

    void Start()
    {
        eventInstanceRef = FMODUnity.RuntimeManager.CreateInstance(soundEffect);
        //eventInstanceRef.start();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eventInstanceRef.start();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eventInstanceRef.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
