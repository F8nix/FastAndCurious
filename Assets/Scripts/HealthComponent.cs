using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] float health = 1000;
    public Action<float, float> OnHealthChanged;

    public float Health {
        get => health;
        private set {
            if (health == value) return;

            float oldHealth = health;
            health = value;
            OnHealthChanged?.Invoke(oldHealth, health);
        }
    }

#if UNITY_EDITOR
    [Header("Debug Health")]
    [SerializeField] private float debugHealthDiff;

    [ContextMenu("Invoke AddDebugHealthDiff")]

    private void InvokeOnHealthChangedEditor() {
        Health += debugHealthDiff;
    }
#endif
}
