using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public WeaponData weaponData;
    
/*
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent component)){
            component.health -= damage;
        }
    }
    */

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent component)){
            component.health.Value -= weaponData.damage;
        }
        Destroy(gameObject);
    }
}
