using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCounter : MonoBehaviour
{
    public double endTimeValue = 90d;

    public int cellsCleared = 0;
    public TextMeshProUGUI endCounter;
    void Update()
    {
        if(endTimeValue > 0d){
            endTimeValue -= Time.deltaTime * GetMultiplier();
            endCounter.text = $"To DEACTIVATION #{Math.Ceiling(endTimeValue)}#";
        } else {
            //jakis event YouGotDeactivated jakby duzo wiecej zaczelo sie dziac, na razie na chama:
            MoneyManager.Instance.SaveMoneyState();
            SceneManager.LoadScene("Shop");
        }
    }

    private double GetMultiplier() {
        if(cellsCleared < 5){
            return 1;
        } else if (cellsCleared < 13){
            return 1.2;
        } else if (cellsCleared < 20) {
            return 1.5;
        } else {
            return 2;
        }
    }
}
