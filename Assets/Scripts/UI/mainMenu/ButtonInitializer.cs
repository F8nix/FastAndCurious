using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ButtonInitializer : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private UpgradeData data;
    public Action<UpgradeData> onButtonClick;
    public void SetName(UpgradeData data) {
        buttonText.text = data.abilityName + " cost " + data.cost.ToString();
        this.data = data;
    }

    public void OnClick() {
        onButtonClick?.Invoke(data);
    }
}
