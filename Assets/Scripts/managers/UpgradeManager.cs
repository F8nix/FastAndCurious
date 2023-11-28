using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance {get; private set; }

    //private Dictionary<bool, (int, string)> upgrades = new Dictionary<bool, (int, string)>();

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        DontDestroyOnLoad(this);
        /* nvm to zmieni sie na SO i Set
        upgrades.Add(false, (20, "weaponTwo"));
        upgrades.Add(false, (50, "weaponThree"));
        */
    }
}
