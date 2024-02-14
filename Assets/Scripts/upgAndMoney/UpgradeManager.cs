using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeData> availableUpgrades;
    public HashSet<UpgradeData> boughtUpgrades;
    public List<UpgradeData> unlockableUpgrades;
    public static UpgradeManager Instance {get; private set; }
    public UnityEvent onUpgradesChange;

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
        if (onUpgradesChange == null){
            onUpgradesChange = new UnityEvent();
        }
    }

    public void BuyUpgrade(UpgradeData upgrade) {
        

        if(!boughtUpgrades.Contains(upgrade) && MoneyManager.Instance.money > upgrade.cost && availableUpgrades.Contains(upgrade)){
            MoneyManager.Instance.money -= upgrade.cost;
            boughtUpgrades.Add(upgrade);
            if(upgrade.isLocking){
                UnlockUpgrades(upgrade);
            }
            onUpgradesChange?.Invoke();
        }

        //debug maly czy cos tam jest
        int entries = 1;
        foreach (var entry in boughtUpgrades)
        { 
            Debug.Log("Entries "+entries);
            entries++;
        }
    }

    public void ResetUpgrades() {
        boughtUpgrades.Clear();
        LockUpgrades();
        onUpgradesChange.Invoke();
    }

    public void UnlockUpgrades(UpgradeData currentUpgrade) {
        HashSet<UpgradeData> upgradesToRemove = new();
        foreach (var upgrade in unlockableUpgrades)
            {
            if(currentUpgrade == upgrade.unlockingUpgrade) {
                //gdyby chcial, moznaby zrobic zamiast jednego wymagania liste wymagan. I dodawac dopiero, jak cala jest spelniona i zdejmowac z odblokowywanych
                availableUpgrades.Add(upgrade);
                upgradesToRemove.Add(upgrade);
                }
            }
            unlockableUpgrades.RemoveAll(upgradesToRemove.Contains);
    }

    public void LockUpgrades() {
        HashSet<UpgradeData> upgradesToRemove = new();
        foreach (var upgrade in availableUpgrades)
        {
            if(upgrade.unlockingUpgrade != null){
                unlockableUpgrades.Add(upgrade);
                upgradesToRemove.Add(upgrade);
            }
        }
        availableUpgrades.RemoveAll(upgradesToRemove.Contains);
    }
}
