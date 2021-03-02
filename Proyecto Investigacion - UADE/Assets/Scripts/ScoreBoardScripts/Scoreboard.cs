using System.IO;
using UnityEngine;

public class Scoreboard : MonoBehaviour //Json will be saved on C:\Users\Name\AppData\LocalLow\DefaultCompany\Proyecto Investigacion - UADE
{
    [SerializeField] private int _maxScoreboardEntries = 5;
    [SerializeField] private Transform _highscoreHolderTransform = null; //Reference to the object that will hold the scores lines (it has vertical layout group)
    [SerializeField] private GameObject _scoreboardEntryObject = null; //This is the row prefab not instantiated that will be instantiated as needed

    [Header("Test")] //This syntax will let you test on editor making right click on the component and select "Test". It will create a new testEntryData
    [SerializeField] private ScoreboardEntryData testEntryData = new ScoreboardEntryData();

    //Application.persistentDataPath will save the file on a dynamic path depending on the user OS
    private string SavePath => $"{Application.persistentDataPath}/highscores.json";

    private void Start()
    {
        ScoreboardSaveData savedScores = GetSavedScoresFromJSonFile();

        UpdateUI(savedScores);
        SaveScores(savedScores);
    }

    [ContextMenu("Add Test Entry")] // This syntax allows you to call a function from inside unity
    public void AddTestEntry() //REMOVE, JUST FOR TESTING PURPOSE
    {
        AddEntry(testEntryData);
    }

    public void AddEntry(ScoreboardEntryData entryScoreToAdd)
    {
        ScoreboardSaveData savedScores = GetSavedScoresFromJSonFile();
        bool scoreAdded = false;

        for (int i = 0; i < savedScores.highScores.Count; i++)
        {
            if(entryScoreToAdd.entryScore > savedScores.highScores[i].entryScore) //If the score stored on I is smaller than the new one (that entryScoreToAdd), entryScoreToAdd will be the new value in that index
            {
                savedScores.highScores.Insert(i, entryScoreToAdd);
                scoreAdded = true;
                break;
            }
        }

        if (!scoreAdded && savedScores.highScores.Count < _maxScoreboardEntries) // In the case that the amount of scores added were less that the maximum scores
        {
            savedScores.highScores.Add(entryScoreToAdd);
        }

        if(savedScores.highScores.Count > _maxScoreboardEntries) //If the amount of scores saved is greater than the max available, remove from the max index to the end to saved scores index.
        {
            savedScores.highScores.RemoveRange(_maxScoreboardEntries, savedScores.highScores.Count - _maxScoreboardEntries);
        }

        UpdateUI(savedScores);
        SaveScores(savedScores);
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

    private ScoreboardSaveData GetSavedScoresFromJSonFile()
    {
        if (!File.Exists(SavePath)) //If the file in that path doesnt exist, then create it and Dispose. Remember to add ".Dispose" to avoid errors
        {
            File.Create(SavePath).Dispose();
            return new ScoreboardSaveData();
        }

        using(StreamReader stream = new StreamReader(SavePath)) //In this method, I create a StreamReader that is in charge of reading a file and will save all into "json" variable
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<ScoreboardSaveData>(json); //This will convert my json variable into a Json data type.
        }
    }

    private void SaveScores(ScoreboardSaveData scoreboardSaveData)
    {
        using (StreamWriter stream = new StreamWriter(SavePath)) //This method will write into that json file
        {
            string json = JsonUtility.ToJson(scoreboardSaveData, true); //PrettyPrint = Display Json in a nice easy to read file
            stream.Write(json);
        }
    }
}
