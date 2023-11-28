using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    public EventableType<float> health = new EventableType<float>(1000);
    public EventableType<float> maxHealth = new EventableType<float>(1000);
    public Action onHealthDepleted;

    private void Start() {
        health.OnValueChanged += HealthCap;
    }

    private void HealthCap(float prevValue, float newValue)
    {
        if(newValue <= 0) {
            health.Value = 0;
            onHealthDepleted?.Invoke();
        } else if (newValue >= maxHealth) {
            health.Value = maxHealth.Value;
        }
    }

#if UNITY_EDITOR
    [Header("Debug Health")]
    [SerializeField] private float debugHealthDiff;

    [ContextMenu("Invoke AddDebugHealthDiff")]

    private void InvokeOnHealthChangedEditor() {
        health.Value += debugHealthDiff;
    }
#endif
}
