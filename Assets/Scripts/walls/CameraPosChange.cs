using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPosChange : MonoBehaviour
{
    public CamOntoTrigger camOntoTriggerInstance;

    public GameObject triggerObject;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //triggerObject.SetActive(false);
        }
    }
}
