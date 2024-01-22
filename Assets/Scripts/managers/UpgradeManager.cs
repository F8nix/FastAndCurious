using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<ScriptableObject> availableUpgrades;
    public HashSet<ScriptableObject> boughtUpgrades;
    public static UpgradeManager Instance {get; private set; }

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        DontDestroyOnLoad(this);
    }

    public void BuyUpgrade(ScriptableObject upgrade) {
        if(!boughtUpgrades.Contains(upgrade)){ // && currency > upgrade.cost czy cos
        //chwilowo nie sprawdzamy kosztu ale potem bedzie trzeba
        boughtUpgrades.Add(upgrade);
        }
    }

    public void ResetUpgrades() {
        boughtUpgrades.Clear();
    }
}
