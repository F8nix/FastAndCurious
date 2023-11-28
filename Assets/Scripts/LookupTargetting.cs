using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LookupTargetting : MonoBehaviour
{
    // Start is called before the first frame update
    public CamOntoTrigger camOntoTriggerInstance;
    public Transform centerLookup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController controller)) {
            CamOntoTrigger.viewTarget = this.transform;
            camOntoTriggerInstance.cameraUpdate.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController controller)) {
            CamOntoTrigger.viewTarget = centerLookup;
            camOntoTriggerInstance.cameraUpdate.Invoke();
        }
    }
}
