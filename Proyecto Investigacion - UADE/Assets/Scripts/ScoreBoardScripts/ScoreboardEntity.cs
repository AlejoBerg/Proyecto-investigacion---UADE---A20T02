using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardEntity : MonoBehaviour
{
    [SerializeField] private int _maxScoreboardEntries = 5;
    [SerializeField] private Transform _highscoreHolderTransform = null; //Reference to the object that will hold the scores lines (it has vertical layout group)
    [SerializeField] private GameObject _scoreboardEntryObject = null; //This is the row prefab not instantiated that will be instantiated as needed

    private Scoreboard _scoreboard;

    private void Awake()
    {
        _scoreboard = new Scoreboard();

        var savedScores = _scoreboard.GetSavedScores();
        UpdateUI(savedScores);
    }

    private void UpdateUI(ScoreboardSaveData savedScores) //This update UI need to know what score to display, thats why I add that reference
    {
        foreach (Transform child in _highscoreHolderTransform) //I made this because if I added a new entry i want to delete all the entries that are already and the repopulate
        {
            Destroy(child.gameObject);
        }

        foreach (ScoreboardEntryData highscore in savedScores.highScores)
        {
            Instantiate(_scoreboardEntryObject, _highscoreHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore); //Now i re instantiate each raw (which is on scoreboardEntryObject because it is a prefab) as a child of the holder of entries. And then initialise that raw which the entry data (that contains the name and score, so it will show that info, otherwise it will be instantiated empty)
        }
    }
}
