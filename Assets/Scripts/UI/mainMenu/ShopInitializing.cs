using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class ShopInitializing : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform gridTransform;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var upgrade in UpgradeManager.Instance.availableUpgrades)
        {
            var button = Instantiate(buttonPrefab, gridTransform);
            var initScript = button.GetComponent<ButtonInitializer>();
            initScript.SetName(upgrade);
            initScript.onButtonClick += UpgradeManager.Instance.BuyUpgrade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
