using UnityEngine;
using TMPro;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _entryNameText = null; //Should have same properties as ScoreboardEntryData (in this case just name and score)
    [SerializeField] private TextMeshProUGUI _entryScoreText = null;

    public void Initialise(ScoreboardEntryData scoreboardEntryData)
    {
        _entryNameText.text = scoreboardEntryData.entryName;
        _entryScoreText.text = scoreboardEntryData.entryScore.ToString();
    }
}
