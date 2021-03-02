using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ScoreboardSaveData //Tell out programm how to save our code
{
    public List<ScoreboardEntryData> highScores = new List<ScoreboardEntryData>();
}
