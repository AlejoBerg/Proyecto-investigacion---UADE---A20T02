using UnityEngine;
using TMPro;

public class SaveUsernameButton : MonoBehaviour
{
    public void SetUsername(TMP_InputField inputFieldUsername)
    {
        string username;

        if (inputFieldUsername.text.Length == 0) { username = "Unknown"; }
        else { username = inputFieldUsername.text; }

        SetScoreboard(username);
    }

    private void SetScoreboard(string username)
    {
        ScoreboardEntryData newEntryData = new ScoreboardEntryData();
        newEntryData.entryName = username;
        newEntryData.entryScore = 0;

        Scoreboard scoreboard = new Scoreboard();
        scoreboard.Initialise(5);
        scoreboard.AddEntry(newEntryData);
    }
}
