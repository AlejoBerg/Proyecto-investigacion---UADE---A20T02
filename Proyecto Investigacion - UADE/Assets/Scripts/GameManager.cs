using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnCoinsChange;
    public event Action OnFinishPlays;

    [SerializeField] private int _amountOfPlays = 5;
    private float _currentPlayed = 0;
    private float _currentCoins = 5;
    
    public float CurrentCoins { get => _currentCoins; }

    public void ChangeCoins(float coinsAmount)
    {
        if(_currentCoins + coinsAmount >= 0)
        {
            _currentCoins += coinsAmount;
        }
        else { _currentCoins = 0; }

        OnCoinsChange?.Invoke();
    }

    public void IncreaseCurrentPlayed() 
    { 
        if(_currentPlayed + 1 < _amountOfPlays)
        {
            _currentPlayed += 1;
            print("_currentPlayed  = " + _currentPlayed);
        }
        else
        {
            OnFinishPlays?.Invoke();
        }
    }

}