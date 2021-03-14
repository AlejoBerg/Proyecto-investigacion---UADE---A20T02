﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _boardLines;//TopLine and Button line 
    [SerializeField] private GameObject _playerDeckOfCards;
    [SerializeField] private GameObject _usedCardsContainer; 
    [SerializeField] private float _sizeOfUsedCards = 0.8f;
    [SerializeField] private FindGameManager _gameManagerFinder;

    private GameManager _gameManagerRef;

    private List<GameObject> _cardsPlayed;

    private void Start()
    {
        _gameManagerRef = _gameManagerFinder.GetGameManagerReference();
    }

    public void ResetGameScene()
    {
        _cardsPlayed = new List<GameObject>();

        GetCardsPlayed();
        SendPlayedCardsToUsed();
        //ReturnCardsPlayedToDeck();
    }

    private List<GameObject> GetCardsPlayed()
    {
        foreach (var line in _boardLines) //Recorro los renglones del tablero, para acceder a sus hijos y agregarlos a "cardsPlayed"
        {
            if (line.transform.childCount > 0)
            {
                foreach (Transform t in line.transform)
                {
                    _cardsPlayed.Add(t.gameObject);
                }
            }
        }
        return _cardsPlayed;
    }

    private void ReturnCardsPlayedToDeck()
    {
        foreach (var card in _cardsPlayed)
        {
            card.transform.parent = _playerDeckOfCards.transform;
            card.transform.eulerAngles = new Vector3(0, card.transform.eulerAngles.y, card.transform.eulerAngles.z); //Reset card rotation
            var played = card.GetComponent<Draggable>();

            if(played != null) { played.Played = false; }

            float cardCost = card.GetComponent<CardDisplay>().CardCost;

            _gameManagerRef.ChangeCoins(_cardsPlayed.Count * cardCost);
        }
    }

    private void SendPlayedCardsToUsed()
    {
        foreach (var card in _cardsPlayed)
        {
            card.transform.localScale = card.transform.localScale * _sizeOfUsedCards;
            card.transform.parent = _usedCardsContainer.transform;
            card.transform.eulerAngles = new Vector3(0, card.transform.eulerAngles.y, card.transform.eulerAngles.z); //Reset card rotation
            var played = card.GetComponent<Draggable>();

            if (played != null) { played.Played = false; }
            Destroy(played);//Removes Draggeable component

            float cardCost = card.GetComponent<CardDisplay>().CardCost;
            _gameManagerRef.ChangeCoins(_cardsPlayed.Count * cardCost);
        }
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }
}
