using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyOnTrigger : MonoBehaviour
{
    public int money = 10;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            MoneyManager.Instance.money += money;
        }
    }
}
