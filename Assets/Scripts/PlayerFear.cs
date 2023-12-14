using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFear : MonoBehaviour
{
    public static PlayerFear instance { get; private set; }
    public float currentFear = 0.0f;
    [SerializeField] private int startingFear = 100;
    [SerializeField] private float maxFear = 100.0f;
    [SerializeField] private Slider fearSlider;
    [SerializeField] private float increaseAmount = 1.0f;
    [SerializeField] private float increaseInterval = 1.0f;
    private float timer = 0.0f;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        fearSlider.minValue = 0.0f;
        fearSlider.maxValue = maxFear;
        fearSlider.value = currentFear;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= increaseInterval)
        {
            timer = 0.0f;
            // Increase fear by the specified amount
            IncreaseFear();
            UpdateSliderValue();
        }
    }

    private void IncreaseFear()
    {
        // Add health by the specified amount
        currentFear += increaseAmount;
        // Clamp health to the maximum value
        currentFear = Mathf.Clamp(currentFear, 0.0f, maxFear);
        //Debug.Log("Current health: " + currentHealth);
    }

    private void UpdateSliderValue()
    {
        fearSlider.value = currentFear;
    }
}