using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class ShopInitializing : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform gridTransform;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        UpgradeManager.Instance.onUpgradesChange.AddListener(UpdateUI);
    }

    private void UpdateUI() {
        foreach (Transform button in gridTransform)
        {
            Destroy(button.gameObject);
        }
        
        foreach (var upgrade in UpgradeManager.Instance.availableUpgrades)
        {
            var button = Instantiate(buttonPrefab, gridTransform);
            var initScript = button.GetComponent<ButtonInitializer>();
            initScript.SetName(upgrade);
            initScript.onButtonClick += UpgradeManager.Instance.BuyUpgrade;

            if(UpgradeManager.Instance.boughtUpgrades.Contains(upgrade)){
                initScript.Sold();
            }
        }
    }
}
