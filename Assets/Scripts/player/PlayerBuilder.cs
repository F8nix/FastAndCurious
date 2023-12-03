using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class PlayerBuilder : MonoBehaviour
{
    public object firstOnQueue;
    public object lastOnQueue;
    public object currentBuilding;
    public Transform indicator;
    public Transform playerBuilder;
    public Transform player;
    public PlayerInputActions playerInputActions;
    public Queue availableBuildingsQueue;

    public GameObject[] buildings;
    
    // Start is called before the first frame update
    private void Awake() {
        playerInputActions = new PlayerInputActions();
        availableBuildingsQueue = new Queue();
    }

    private void OnEnable() {
        playerInputActions.Player.Build.performed += BuildingManager;
        playerInputActions.Player.Build.Enable();
    }

    private void OnDisable() {
        playerInputActions.Player.Build.Disable();
    }

    void Start()
    {
        //availableBuildingsQueue.Enqueue("Building2");
        //availableBuildingsQueue.Enqueue("Building3");
        //availableBuildingsQueue.Enqueue("Building1");
        BuilderInitialization(buildings);
        if(currentBuilding == null) {
            currentBuilding = availableBuildingsQueue.Peek();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void BuildingManager(InputAction.CallbackContext context)
    {
        //switching buidings
        if(context.ReadValue<float>() == 1) {
            firstOnQueue = availableBuildingsQueue.Peek();
            availableBuildingsQueue.Dequeue();
            availableBuildingsQueue.Enqueue(firstOnQueue);
        }
        if(context.ReadValue<float>() == 2) {
            for(int queued = 1; queued < availableBuildingsQueue.Count; queued++){
                lastOnQueue = availableBuildingsQueue.Peek();
                availableBuildingsQueue.Dequeue();
                availableBuildingsQueue.Enqueue(lastOnQueue);
            }
        }

        //switching rotation
        if(context.ReadValue<float>() == 3) {
            ChangeRotation(false, playerBuilder);
        }
        if(context.ReadValue<float>() == 4) {
            ChangeRotation(true, playerBuilder);
        }

        //building
        if(context.ReadValue<float>() == 5) {
            UnityEngine.Vector3 buildingPos = new UnityEngine.Vector3(indicator.position.x, indicator.position.y, indicator.position.z);
            //Instantiate(availableBuildingsQueue.Peek(), buildingPos);
        }
    }

    public void ChangeRotation (bool turnsRight, Transform rotatedObject){
        
        UnityEngine.Vector3 rotationStrength = new UnityEngine.Vector3(0,0,0);
        float degrees = 45f;
        if (turnsRight){
            rotationStrength.Set(0, degrees, 0);
        } else {
            rotationStrength.Set(0, -degrees, 0);
        }
        rotatedObject.transform.Rotate(rotationStrength);
    }

    public void BuilderInitialization(GameObject[] buildings) {
        for (int i = 1; i < buildings.Length; i++){
            availableBuildingsQueue.Enqueue(buildings[i]);
        }
        availableBuildingsQueue.Enqueue(buildings[0]);
    }
}