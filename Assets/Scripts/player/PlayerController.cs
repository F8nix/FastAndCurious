using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Handing
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;

    public ProjectileShooting shooter;

    private Quaternion targetRotation;

    private CharacterController controller;

    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        movement = playerInputActions.Player.Movement;
        movement.Enable();

        playerInputActions.Player.Shoot.performed += DoJump;
        playerInputActions.Player.Shoot.Enable();

        playerInputActions.Player.Run.Enable();
    }

    private void OnDisable() {
        movement.Disable();
        playerInputActions.Player.Shoot.Disable();
        playerInputActions.Player.Run.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 movementValue = movement.ReadValue<Vector2>();
        Vector3 input = new Vector3(movementValue.x, 0, movementValue.y);

        if (input != Vector3.zero) {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;

        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        motion *= playerInputActions.Player.Run.IsPressed()?runSpeed:walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }

     private void DoJump(InputAction.CallbackContext context)
    {
        shooter.Shoot();
    }
}
