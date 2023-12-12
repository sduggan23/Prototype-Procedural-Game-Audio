using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioControl : MonoBehaviour
{
    private EventInstance eventInstanceRef;


    [SerializeField] private string soundEffect;
    [SerializeField] private string gameStartedParameter;
    [SerializeField] private string gameHalfwayParameter;
    [SerializeField] private string gameEndedParameter;



    void Start()
    {
        eventInstanceRef = RuntimeManager.CreateInstance(soundEffect);

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

    public void SoundStarted()
    {
        eventInstanceRef.setParameterByName(gameStartedParameter, 1f);
    }

    public void Halfway()
    {
        eventInstanceRef.setParameterByName(gameHalfwayParameter, 1f);
    }

    public void SoundEnded()
    {
        eventInstanceRef.setParameterByName(gameEndedParameter, 1f);
    }

}
