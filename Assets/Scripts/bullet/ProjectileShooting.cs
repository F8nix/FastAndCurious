using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletPrefab;
    public WeaponData weaponData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot")) {
        //if (Input.GetKeyDown(KeyCode.Space)) { //weaponData.bulletPrefab jak w SO bedzie + delay
            Transform bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().velocity = (transform.forward * weaponData.projectileSpeed);
            bulletInstance.GetComponent<BulletCollision>().weaponData = weaponData;
        }
    }
}
