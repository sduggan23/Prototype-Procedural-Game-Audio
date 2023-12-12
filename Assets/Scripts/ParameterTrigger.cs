using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterTrigger : MonoBehaviour
{
    [SerializeField] private string parameterName;
    [SerializeField] private float parameterValue;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.SetAmbienceParameter(parameterName, parameterValue);
        }
    }
}
