using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCounter : MonoBehaviour
{
    public double endTimeValue = 90d;
    public TextMeshProUGUI endCounter;
    void Update()
    {
        if(endTimeValue > 0d){
            endTimeValue -= Time.deltaTime;
            endCounter.text = $"To DEACTIVATION #{Math.Ceiling(endTimeValue)}#";
        } else {
            //jakis event YouGotDeactivated jakby duzo wiecej zaczelo sie dziac, na razie na chama:
            MoneyManager.Instance.SaveMoneyState();
            SceneManager.LoadScene("Shop");
        }
    }
}
