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

    //public void SetUsername(TMP_InputField inputFieldUsername)
    //{
    //    string username;

    //    if (inputFieldUsername.text.Length == 0) { username = "Unknown"; }
    //    else { username = inputFieldUsername.text; }

    //    SetScoreboard(username);
    //}

    //private void SetScoreboard(string username)
    //{
    //    ScoreboardEntryData newEntryData = new ScoreboardEntryData();
    //    newEntryData.entryName = username;
    //    newEntryData.entryScore = 0;

    //    Scoreboard scoreboard = new Scoreboard();
    //    scoreboard.Initialise(5);
    //    scoreboard.AddEntry(newEntryData);
    //}
}
