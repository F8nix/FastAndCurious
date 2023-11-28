using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CamOntoTrigger : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera _virtualCamera;
    public UnityEvent cameraUpdate;
    public static Transform viewTarget;
    // Start is called before the first frame update

    public CamOntoTrigger(){}

    private void Awake() {
        _virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    void Start()
    {
        if(cameraUpdate == null){
            cameraUpdate = new UnityEvent();
        }
        cameraUpdate.AddListener(LookAtTarget);
    }

    // Update is called once per frame
    private void LookAtTarget() {
        _virtualCamera.LookAt = viewTarget;
    }
}
