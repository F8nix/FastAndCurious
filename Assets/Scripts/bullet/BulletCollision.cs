using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent component)){
            component.health -= damage;
        }
    }
    */

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent component)){
            component.health -= damage;
        }
        Destroy(gameObject);
    }
}
