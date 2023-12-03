using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour
{
    public void ChangeScene() {
        MoneyManager.Instance.SaveMoneyState();
        SceneManager.LoadScene("Shop");
    }
}