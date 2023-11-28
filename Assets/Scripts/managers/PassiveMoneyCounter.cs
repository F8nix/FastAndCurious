using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveMoneyCounter : MonoBehaviour
{
    private float moneyTimeCurrent;
    public float moneyTimeStartValue = 2.5f;
    public int moneyGain = 1;

    private void Start() {
        moneyTimeCurrent = moneyTimeStartValue;
    }
    void Update()
    {
        if(moneyTimeCurrent > 0f){
            moneyTimeCurrent -= Time.deltaTime;
        } else {
            MoneyManager.Instance.money += moneyGain;
            moneyTimeCurrent = moneyTimeStartValue;
        }
    }
}
