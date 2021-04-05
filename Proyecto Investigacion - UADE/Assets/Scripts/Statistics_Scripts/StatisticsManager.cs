using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] private GameObject _playAgainButtonRef;
    [SerializeField] private GameObject _endGameButtonRef;
    [SerializeField] private FindGameManager _gameManagerFinder;
    [SerializeField] private float _delayToShowFinishButton = 2.3f;

    private GameManager _gameManagerRef;

    private void Start()
    {
        _gameManagerRef = _gameManagerFinder.GetGameManagerReference();
        _gameManagerRef.OnFinishPlays += OnFinishPlaysHandler;
    }

    private void OnFinishPlaysHandler()
    {
        _playAgainButtonRef.SetActive(false);
        _endGameButtonRef.SetActive(true);
    }

    IEnumerator DelayToUnhide()
    {
        yield return new WaitForSeconds(_delayToShowFinishButton);
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }
}
