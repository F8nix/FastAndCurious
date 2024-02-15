using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthComponent))]
public class DestructOnNoHp : MonoBehaviour
{
    public GameObject cameraTriggerLookup;
    
    void Start()
    {
        var healthComponent = GetComponent<HealthComponent>();
        healthComponent.onHealthDepleted += OnDeath;
    }

    private void OnDeath() {
        cameraTriggerLookup.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
