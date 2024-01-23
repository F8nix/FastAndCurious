using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "SO/UpgradeData", order = 1)]
public class UpgradeData : ScriptableObject {
    public string abilityName;
    public int cost;
}