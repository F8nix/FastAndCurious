using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent component)){
            component.health.Value -= damage;
        }
    }
}
