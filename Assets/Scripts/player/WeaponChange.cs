using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponChange : MonoBehaviour
{
    public List<WeaponData> weapons = new List<WeaponData>();
    public ProjectileShooting projectileShooting;
    public PlayerInputActions playerInputActions;

    
    private void Awake() {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        playerInputActions.Player.ChangeWeapon.performed += WeaponManager;
        playerInputActions.Player.ChangeWeapon.Enable();
    }
    
    void Start()
    {
        projectileShooting.weaponData = weapons[0];
    }

    void Update()
    { 
    }

    private void WeaponManager(InputAction.CallbackContext context)
    {
        int index = (int) (context.ReadValue<float>()-1);
        projectileShooting.weaponData = weapons[index];
    }
}
