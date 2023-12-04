using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBuilder : MonoBehaviour
{
    public Transform indicator;
    public Transform playerBuilder;
    public Transform player;
    public IndicatorAppearence indicatorAppearence;
    public PlayerInputActions playerInputActions;
    public GameObject[] buildings;
    public int buildingIndex = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void Start() {
        indicatorAppearence.SetAppearence(buildings[0]);
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.ChangeBuidling.performed += ChangeBuilding;
        playerInputActions.Player.RotateIndicator.performed += RotateIndicator;
        playerInputActions.Player.Build.performed += Build;
    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    void Update()
    {
        transform.position = player.position;
    }

    private void ChangeBuilding(InputAction.CallbackContext context)
    {
        buildingIndex += (int) context.ReadValue<float>();
        buildingIndex = (buildingIndex + buildings.Length) % buildings.Length;
        indicatorAppearence.SetAppearence(buildings[buildingIndex]);
    }
    private void RotateIndicator(InputAction.CallbackContext context)
    {
        float degrees = 45f * context.ReadValue<float>();
        Vector3 rotationStrength = new Vector3(0, degrees, 0);
        playerBuilder.transform.Rotate(rotationStrength);
    }
    private void Build(InputAction.CallbackContext context)
    {
        Quaternion buildingRotation = Quaternion.Euler(indicator.position);
        Instantiate(buildings[buildingIndex], indicator.position, buildingRotation);
    }
}