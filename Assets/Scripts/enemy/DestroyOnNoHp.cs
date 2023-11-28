using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class DestroyOnNoHp : MonoBehaviour
{
    void Start()
    {
        var healthComponent = GetComponent<HealthComponent>();
        healthComponent.onHealthDepleted += OnDeath;
    }

    private void OnDeath() {
        Destroy(gameObject);
    }
}
