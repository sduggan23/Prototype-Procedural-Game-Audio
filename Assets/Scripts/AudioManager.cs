using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private List<EventInstance> eventInstances = new List<EventInstance>();     // List to store multiple EventInstances

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        // Initialise multiple ambience events at the start
        InitializeAmbience(FMODEvents.instance.heartbeatGain);
        InitializeAmbience(FMODEvents.instance.heartbeatPitch);

    }

    private void InitializeAmbience(EventReference ambienceEventRef)
    {
        // Create a new EventInstance for the specified EventReference
        EventInstance newEventInstance = RuntimeManager.CreateInstance(ambienceEventRef);

        // Create a new EventInstance for the specified EventReference
        newEventInstance.start();

        // Add the new EventInstance to the list for further control
        eventInstances.Add(newEventInstance);
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        // Set a parameter value for all EventInstances in the list
        foreach (var eventInstance in eventInstances)
        {
            eventInstance.setParameterByName(parameterName, parameterValue);
        }
    }

}
