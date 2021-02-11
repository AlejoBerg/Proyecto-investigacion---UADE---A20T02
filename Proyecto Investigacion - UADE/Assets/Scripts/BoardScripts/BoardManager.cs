using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _boardLines;//TopLine and Button line 
    [SerializeField] private GameObject _playerDeckOfCards;//TopLine and Button line 

    private List<GameObject> _cardsPlayed;

    public void OnFinishMatchButtonPressed()
    {
        _cardsPlayed = new List<GameObject>();

        GetCardsPlayed();
        ReturnCardsPlayedToDeck();
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
        }
    }
}
