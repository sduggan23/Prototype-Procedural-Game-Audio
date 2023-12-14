using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterIncrease : MonoBehaviour
{
    [SerializeField] private string parameterName;
    //[SerializeField] private float parameterValue;

    void Update()
    {
        AudioManager.instance.SetAmbienceParameter(parameterName, PlayerFear.instance.currentFear);
    }
}
