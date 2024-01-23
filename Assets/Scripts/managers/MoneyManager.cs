using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance {get; private set; }

    public TextMeshProUGUI moneyCounter;
    public int money;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
            if(!PlayerPrefs.HasKey("Money")) {
                PlayerPrefs.SetInt("Money", 0);
            }
        }
    }

    private void Start() {
        DontDestroyOnLoad(this);
        money = PlayerPrefs.GetInt("Money");
        moneyCounter.text = "money";
    }

    public void SaveMoneyState() {
        PlayerPrefs.SetInt("Money", money);
    }

    public void ResetMoneyState() {
        money = 0;
        PlayerPrefs.SetInt("Money", 0);
    }

    private void Update() {
        moneyCounter.text = $"$$$: {money}";
    }

    #if UNITY_EDITOR
    [Header("Debug moeny")]
    [SerializeField] private int debugMoney;

    [ContextMenu("Invoke AddDebugMoneyDiff")]

    private void InvokeOnHealthChangedEditor() {
        money += debugMoney;
    }
#endif
}
