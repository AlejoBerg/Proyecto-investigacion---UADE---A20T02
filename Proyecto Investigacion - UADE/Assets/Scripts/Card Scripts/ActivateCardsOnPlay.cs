using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCardsOnPlay : MonoBehaviour
{
    [SerializeField] private CardDisplay[] _currentCardsOnScene;
    private GameManager _gameManagerRef;

    private void Awake()
    {
        CacheGameManager();
        DeactivateInitCards();

        ActivateProvinceNeededCards(_gameManagerRef.CardsIDsToActivate);
    }

    public void ActivateProvinceNeededCards(string[] cardsIDsToActivate)
    {
        for (int i = 0; i < cardsIDsToActivate.Length; i++)
        {
            string cardIDToActivate = cardsIDsToActivate[i];

            for (int j = 0; j < _currentCardsOnScene.Length; j++)
            {
                var currentCardOnScene = _currentCardsOnScene[j];

                if (currentCardOnScene.Card.CardID.ToString() == cardIDToActivate)
                {
                    currentCardOnScene.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void DeactivateInitCards()
    {
        for (int i = 0; i < _currentCardsOnScene.Length; i++)
        {
            _currentCardsOnScene[i].gameObject.SetActive(false);
        }
    }

    private void CacheGameManager()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManagerRef = gameManager.GetComponent<GameManager>();
    }
}
