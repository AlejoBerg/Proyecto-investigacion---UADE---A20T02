using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameManager : MonoBehaviour
{
    private GameManager _gameManagerRef; //This class was created to avoid making more than one find object with tag inside the same scene

    public GameManager GetGameManagerReference()
    {
        CacheGameManager();
        return _gameManagerRef;
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }
}
