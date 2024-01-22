using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
            initScript.SetName(upgrade.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
