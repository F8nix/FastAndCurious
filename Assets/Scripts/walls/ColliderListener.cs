using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderListener : MonoBehaviour
{
    public UnityEvent<Collision> onCollisionEnter;
    public UnityEvent<Collider> onTriggerEnter;

    private void OnCollisionEnter(Collision other) {
        onCollisionEnter.Invoke(other);
    }  

    private void OnTriggerEnter(Collider other) {
        onTriggerEnter.Invoke(other);
    }
}
