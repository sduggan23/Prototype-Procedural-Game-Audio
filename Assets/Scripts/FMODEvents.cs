using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvents : MonoBehaviour
{

    public static FMODEvents instance { get; private set; }
    [field: Header("Heartbeat")]
    [field: SerializeField] public EventReference heartbeatGain { get; private set; }
    [field: SerializeField] public EventReference heartbeatPitch { get; private set; }


    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

}
