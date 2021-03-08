using System.IO;
using UnityEngine;

public class Scoreboard  //Json will be saved on C:\Users\Name\AppData\LocalLow\DefaultCompany\Proyecto Investigacion - UADE
{
    private int _maxScoreboardEntries;
    private string SavePath => $"{Application.persistentDataPath}/highscores.json";

    public void Initialise(int maxScoreboardEntries)
    {
        _maxScoreboardEntries = maxScoreboardEntries;
        var savedScores = GetSavedScores();

        SaveScores(savedScores);
    }

    public ScoreboardSaveData GetSavedScores()
    {
        ScoreboardSaveData savedScores = GetSavedScoresFromJSonFile();
        return savedScores;
    }

    public void AddEntry(ScoreboardEntryData entryScoreToAdd)
    {
        ScoreboardSaveData savedScores = GetSavedScoresFromJSonFile();
        bool scoreAdded = false;

        for (int i = 0; i < savedScores.highScores.Count; i++)
        {
            if(entryScoreToAdd.entryScore > savedScores.highScores[i].entryScore)
            {
                savedScores.highScores.Insert(i, entryScoreToAdd);
                scoreAdded = true;
                break;
            }
        }

        if (!scoreAdded && savedScores.highScores.Count < _maxScoreboardEntries)
        {
            savedScores.highScores.Add(entryScoreToAdd);
        }

        if(savedScores.highScores.Count > _maxScoreboardEntries)
        {
            savedScores.highScores.RemoveRange(_maxScoreboardEntries, savedScores.highScores.Count - _maxScoreboardEntries);
        }

        SaveScores(savedScores);
    }

    private ScoreboardSaveData GetSavedScoresFromJSonFile()
    {
        if (!File.Exists(SavePath))
        {
            File.Create(SavePath).Dispose();
            return new ScoreboardSaveData();
        }

        using(StreamReader stream = new StreamReader(SavePath))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<ScoreboardSaveData>(json);
        }
    }

    private void SaveScores(ScoreboardSaveData scoreboardSaveData)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(scoreboardSaveData, true); 
            stream.Write(json);
        }
    }
}
