using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameFunc() {
        Application.Quit(); //works on build only and not use this code on iOS
    }
}
