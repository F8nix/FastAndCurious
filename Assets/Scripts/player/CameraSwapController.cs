using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwapController : MonoBehaviour
{
    public CamOntoTrigger currentCam;

    private void OnTriggerEnter(Collider other) {

        if (other.TryGetComponent<CameraPosChange>(out var nextCam)) {
            currentCam.gameObject.SetActive(false);
            currentCam = nextCam.camOntoTriggerInstance;
            currentCam.gameObject.SetActive(true);
        }
    }
}
