using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LookupTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public CamOntoTrigger camOntoTriggerInstance;
    public Transform centerLookup;
    public SeeThrough seeThroughWall;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            camOntoTriggerInstance.LookAtTarget(this.transform);
        }
        seeThroughWall.SetTransparent();
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            camOntoTriggerInstance.LookAtTarget(centerLookup);
        }
        seeThroughWall.SetNormal();
    }
}
