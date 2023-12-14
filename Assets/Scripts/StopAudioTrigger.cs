using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class StopAudioTrigger : MonoBehaviour
{
    [SerializeField] private string soundEffect = "event:/Character/Breathing";

    private EventInstance eventInstanceRef;

    void Start()
    {
        eventInstanceRef = FMODUnity.RuntimeManager.CreateInstance(soundEffect);
        //eventInstanceRef.start();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopSound();
        }
    }

    private void StopSound()
    {
        eventInstanceRef.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //eventInstanceRef.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
