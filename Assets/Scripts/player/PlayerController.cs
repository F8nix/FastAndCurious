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

    private void Awake() {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        playerInputActions.Player.Shoot.performed += Shoot;
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

        motion *= playerInputActions.Player.Run.IsPressed()?runSpeed:walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }

     private void Shoot(InputAction.CallbackContext context)
    {
        shooter.Shoot();
    }
}
