using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] LayerMask targetable;
    public ProjectileShooting shooter;
    public Transform turretRotator;
    public WeaponData weaponData;
    public float rotationSpeed = 1;
    public float range = 2.5f;
    private void Start() {
        shooter.weaponData = weaponData;
    }

    private void Update() { //to cleanup?
        Collider[] targets = new Collider[3];
        int targetCount = Physics.OverlapSphereNonAlloc(transform.position, range, targets, targetable);
        if(targetCount == 0){
            return;
        }
        var target = targets[0];
        var targetPosition = target.transform.position;
        targetPosition.y = 0;
        var rotatorPosition = turretRotator.position;
        rotatorPosition.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - rotatorPosition);
        turretRotator.rotation = Quaternion.Slerp(turretRotator.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        shooter.Shoot();
    }
}
