using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class TeleportOnNoHp : MonoBehaviour
{
    public List<Vector3> teleportPositions = new List<Vector3>();
    private HealthComponent healthComponent;
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.onHealthDepleted += OnDeath;
    }

    // Update is called once per frame
    private void OnDeath()
    {
        StartCoroutine(healthComponent.ResetHealth());
        int collidersCount;
        int newPosition;
        int iteratorCount = 10;
        do
        {
            newPosition = Random.Range(0, teleportPositions.Count);
            Collider[] colliders = new Collider[3];
            collidersCount = Physics.OverlapSphereNonAlloc(teleportPositions[newPosition], 0.25f, colliders);
        } while (collidersCount > 0 && --iteratorCount > 0);
        if (iteratorCount > 0)
        {
            transform.position = teleportPositions[newPosition];
        }
    }
}
