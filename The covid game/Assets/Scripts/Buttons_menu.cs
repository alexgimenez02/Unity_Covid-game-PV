using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_menu : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void MatarJuego()
    {
        Application.Quit();
    }
}