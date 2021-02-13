using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _currentCoins = 5;
    
    public event Action OnCoinsChange;
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
}