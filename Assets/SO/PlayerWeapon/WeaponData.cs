using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/WeaponData", order = 0)]
public class WeaponData : ScriptableObject {
    public float damage;
    public float projectileSpeed;
    public float firingDelay;
    public GameObject bulletPrefab;
    public GameObject weaponPrefab;
}