using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Handing
    public float rotationSpeed = 450;

    private float movementSpeed = 5;
    public float walkSpeed = 5;
    public float runSpeed = 8;

    private bool speedUpActive;

    public float speedUpDuration = 5.0f;
    public float speedUpCooldown = 20.0f;

    public ProjectileShooting shooter;

    private Quaternion targetRotation;

    private CharacterController controller;

    private PlayerInputActions playerInputActions;

    public UpgradeData speedUpUpgrade;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        playerInputActions.Player.Shoot.performed += Shoot;
        if(UpgradeManager.Instance.boughtUpgrades.Contains(speedUpUpgrade)) {
        playerInputActions.Player.Run.performed += OnSpeedUpKeyPress;
        }
        playerInputActions.Player.Enable();
    }

    private void OnDisable() {
        playerInputActions.Player.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 movementValue = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 input = new Vector3(movementValue.x, 0, movementValue.y);

        if (input != Vector3.zero) {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input.normalized;

        motion *= movementSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }

     private void Shoot(InputAction.CallbackContext context)
    {
        shooter.Shoot();
    }

    private void OnSpeedUpKeyPress(InputAction.CallbackContext context) {
        StartCoroutine(TryActivateSpeedUp());
    }

    IEnumerator TryActivateSpeedUp()
    {
        if(UpgradeManager.Instance.boughtUpgrades.Contains(speedUpUpgrade)) {
            if(!speedUpActive){
                movementSpeed = runSpeed;
                speedUpActive = true;
                yield return new WaitForSeconds(speedUpDuration);
                movementSpeed = walkSpeed;
                yield return new WaitForSeconds(speedUpCooldown);
                speedUpActive = false;
            }
        }
    }
}
