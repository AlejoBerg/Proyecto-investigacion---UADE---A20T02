using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManagerRef;
    [SerializeField] private GameObject _playAgainButtonRef;
    [SerializeField] private GameObject _endGameButtonRef;

    private void Start()
    {
        CacheGameManager();
        _gameManagerRef.OnFinishPlays += OnFinishPlaysHandler;
    }

    private void OnFinishPlaysHandler()
    {
        _playAgainButtonRef.SetActive(false);
        _endGameButtonRef.SetActive(true);
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }
}
