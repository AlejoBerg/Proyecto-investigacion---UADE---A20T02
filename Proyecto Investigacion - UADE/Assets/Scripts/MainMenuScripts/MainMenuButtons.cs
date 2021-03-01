using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void OnPlayGameButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnExitGameButton()
    {
        print("Quitting Game");
        Application.Quit();
    }
}
