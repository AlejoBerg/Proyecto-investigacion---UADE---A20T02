using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _currentCoins = 100;

    public void ChangeCoins(float coinsAmount)
    {
        if(_currentCoins + coinsAmount >= 0)
        {
            _currentCoins += coinsAmount;
        }
        else { _currentCoins = 0; }
    }
}