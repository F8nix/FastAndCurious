using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene("Shop");
    }
}