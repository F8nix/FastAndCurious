using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonInitializer : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public void SetName(string text) {
        buttonText.text = text;
    }
}
