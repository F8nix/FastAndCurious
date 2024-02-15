using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnergyComponent : MonoBehaviour
{
    public EventableType<float> energy = new EventableType<float>(1000);
    public EventableType<float> maxEnergy = new EventableType<float>(1000);
    public Action onEnergyDepleted;

    private void Start() {
        energy.OnValueChanged += EnergyCap;
    }

    private void EnergyCap(float prevValue, float newValue)
    {
        if(newValue <= 0) {
            energy.Value = 0;
            onEnergyDepleted?.Invoke();
        } else if (newValue >= maxEnergy) {
            energy.Value = maxEnergy.Value;
        }
    }

    public IEnumerator ResetEnergy() {
        yield return new WaitForEndOfFrame();
        energy.Value = maxEnergy;
    } 

#if UNITY_EDITOR
    [Header("Debug Energy")]
    [SerializeField] private float debugEnergyDiff;

    [ContextMenu("Invoke AddDebugEnergyDiff")]

    private void InvokeOnEnergyChangedEditor() {
        energy.Value += debugEnergyDiff;
    }
#endif
}
