using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterControl : MonoBehaviour
{
    public AudioControl audioControl;
    private bool isEnded = false;

    [FMODUnity.EventRef]
    [SerializeField] private string soundEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isEnded == false)
        {
            audioControl.Halfway();
            isEnded = false;
            Debug.Log("Halfway");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioControl.SoundEnded();
            isEnded = true;
            Debug.Log("Ended");
        }
    }
}
