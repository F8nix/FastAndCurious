using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamOntoTrigger : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera _virtualCamera;

    public CamOntoTrigger(){}

    private void Awake() {
        _virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    public void LookAtTarget(Transform viewTarget) {
        _virtualCamera.LookAt = viewTarget;
    }
}
