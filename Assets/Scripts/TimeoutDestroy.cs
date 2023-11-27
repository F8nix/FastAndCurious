using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float timeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
