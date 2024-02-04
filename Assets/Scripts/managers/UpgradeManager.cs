using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeData> availableUpgrades;
    public HashSet<UpgradeData> boughtUpgrades;
    public static UpgradeManager Instance {get; private set; }

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
        boughtUpgrades = new HashSet<UpgradeData>();
    }

    private void Start() {
        DontDestroyOnLoad(this);
    }

    public void BuyUpgrade(UpgradeData upgrade) {
        if(!boughtUpgrades.Contains(upgrade) && MoneyManager.Instance.money > upgrade.cost){
        MoneyManager.Instance.money -= upgrade.cost;
        boughtUpgrades.Add(upgrade);
        }
        int entries = 1;
        foreach (var entry in boughtUpgrades)
        { 
            Debug.Log("Entries "+entries);
            entries++;
        }
    }

    public void ResetUpgrades() {
        boughtUpgrades.Clear();
    }
}
