using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cam;
    void Start()
    {
        //cam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.forward = cam.position;
    }
}
