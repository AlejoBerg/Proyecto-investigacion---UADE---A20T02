using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _matchesLeftText;
    [SerializeField] private FindGameManager _gameManagerFinder;

    private GameManager _gameManagerRef;

    private void Start()
    {
        _gameManagerRef = _gameManagerFinder.GetGameManagerReference();
        SetText();
    }

    public void OnEndMatchPressed()
    {
        _gameManagerRef.IncreaseCurrentPlayed();
        SetText();
    }

    private void SetText()
    {
        string amountOfPlays = _gameManagerRef.AmountOfPlays.ToString();
        string currentPlayed = _gameManagerRef.CurrentPlayed.ToString();
        _matchesLeftText.text = currentPlayed + "/" + amountOfPlays;
    }
}
