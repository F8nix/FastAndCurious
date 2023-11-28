using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthbarUpdate : MonoBehaviour
{
    private Slider slider;
    public HealthComponent healthComponent;

    void Start()
    {
        slider = GetComponent<Slider>();
        healthComponent.health.OnValueChanged += UpdateHealthBar;
        slider.maxValue = healthComponent.maxHealth;
        slider.minValue = 0;
        slider.value = healthComponent.health;
    }

    private void UpdateHealthBar(float prevValue, float newValue) {
        slider.value = newValue;
    }
}
