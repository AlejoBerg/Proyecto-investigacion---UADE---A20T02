using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _matchesLeftText;
    private GameManager _gameManagerRef;

    private void Start()
    {
        CacheGameManager();
        SetText();
    }

    public void OnEndMatchPressed()
    {
        _gameManagerRef.IncreaseCurrentPlayed();
        SetText();
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }

    private void SetText()
    {
        string amountOfPlays = _gameManagerRef.AmountOfPlays.ToString();
        string currentPlayed = _gameManagerRef.CurrentPlayed.ToString();
        _matchesLeftText.text = currentPlayed + "/" + amountOfPlays;
    }
}
