using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletPrefab;
    int forwardForce = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot")) {
        //if (Input.GetKeyDown(KeyCode.Space)) {
            Transform bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
        }
    }
}
