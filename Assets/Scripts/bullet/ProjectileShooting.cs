using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponData weaponData;
    private float cooldown;
    void Update()
    {
        if(cooldown > 0){
            cooldown -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    public void Shoot()
    {
        if(cooldown > 0) return;
        Transform bulletInstance = Instantiate(weaponData.bulletPrefab.transform, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().velocity = (transform.forward * weaponData.projectileSpeed);
        bulletInstance.GetComponent<BulletCollision>().weaponData = weaponData;
        cooldown = weaponData.firingDelay;
    }
}
