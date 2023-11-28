using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public List<WeaponData> weapons = new List<WeaponData>();
    public ProjectileShooting projectileShooting;
    // Start is called before the first frame update
    void Start()
    {
        projectileShooting.weaponData = weapons[0];
    }

    // Update is called once per frame
    void Update()
    { //to be changed to input sys
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            projectileShooting.weaponData = weapons[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            projectileShooting.weaponData = weapons[1];
        } else if (Input.GetKeyDown(KeyCode.Alpha3)){
            projectileShooting.weaponData = weapons[2];
        }
    }
}
