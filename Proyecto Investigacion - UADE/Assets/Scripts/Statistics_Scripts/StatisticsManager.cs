using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManagerRef;
    [SerializeField] private GameObject _playAgainButtonRef;
    [SerializeField] private GameObject _endGameButtonRef;

    private void Awake()
    {
        _gameManagerRef.OnFinishPlays += OnFinishPlaysHandler;
    }

    private void OnFinishPlaysHandler()
    {
        _playAgainButtonRef.SetActive(false);
        _endGameButtonRef.SetActive(true);
    }
}
