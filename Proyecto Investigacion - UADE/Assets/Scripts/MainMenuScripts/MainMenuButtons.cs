using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    public void OnChangeSceneButtonPressed(string sceneName = "StartScene")
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnExitGameButton()
    {
        print("Quitting Game");
        Application.Quit();
    }
}
