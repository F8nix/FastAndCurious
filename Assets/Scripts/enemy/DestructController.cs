using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

public class DestructController : MonoBehaviour
{
    public int version;
    public float toxicityDelay;

    public int moneyGain;
    private HealthComponent healthComponent;

    public List<Material> materials;

    public CellDirection direction;

    public UnityEvent<CellData> onDestroy;

    public GameObject cameraTriggerLookup;
    
    private void OnEnable() {
        version = Random.Range(0,3);

        healthComponent = GetComponent<HealthComponent>();
        healthComponent.onHealthDepleted += OnDeath;

        var renderer = GetComponent<Renderer>();

        renderer.material = materials[version];
        switch (version)
        {
            case 0:
                healthComponent.maxHealth.Value = 5; //poprawic energy componenta
                healthComponent.health.Value = 5;
                toxicityDelay = 4.0f;
                moneyGain = 5;
                break;
            case 1:
                healthComponent.maxHealth.Value = 3;
                healthComponent.health.Value = 3;
                toxicityDelay = 2.5f;
                moneyGain = 4;
                break;
            case 2:
                healthComponent.maxHealth.Value = 2;
                healthComponent.health.Value = 2;
                toxicityDelay = 2.0f;
                moneyGain = 3;
                break;
        }
    }

    private void OnDisable() {
        healthComponent.onHealthDepleted -= OnDeath;
    }

    private void OnDeath() {
        cameraTriggerLookup.SetActive(true);
        healthComponent.health.Value = healthComponent.maxHealth.Value;
        this.gameObject.SetActive(false);
        onDestroy?.Invoke(new CellData{money = moneyGain, direction = direction, toxicity = toxicityDelay});
    }
}

public class CellData{
    public int money;
    public CellDirection direction;

    public float toxicity;
}