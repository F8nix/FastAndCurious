using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    public EventableType<float> health = 1000;

#if UNITY_EDITOR
    [Header("Debug Health")]
    [SerializeField] private float debugHealthDiff;

    [ContextMenu("Invoke AddDebugHealthDiff")]

    private void InvokeOnHealthChangedEditor() {
        health += debugHealthDiff;
    }
#endif
}
