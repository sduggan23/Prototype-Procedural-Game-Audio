using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioTrigger : MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private FMOD.Studio.EventInstance eventInstanceRef;

    void Start()
    {
        eventInstanceRef = FMODUnity.RuntimeManager.CreateInstance(path);
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
    }
}
