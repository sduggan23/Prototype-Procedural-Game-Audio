using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private EventInstance ambienceEventInstance;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        InitializeAmbience(FMODEvents.instance.ambience);
    }



    private void InitializeAmbience(EventReference ambienceEventRef)
    {
        ambienceEventInstance = RuntimeManager.CreateInstance(ambienceEventRef);
        ambienceEventInstance.start();
    }
    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parameterValue);
    }
}
