using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCardsSlider : MonoBehaviour
{
    [SerializeField] private float _cardsSizeOnSlider = 0.9f;

    private Vector3 _initCardsSize = Vector3.zero;
    private HelpGraphButton _currentClickedButton = null;
    private GameObject _currentCardsParent = null;
    private List<GameObject> _currentSliderCards = new List<GameObject>();

    public void SetNewCardsOnSlider(HelpGraphButton currentClickedButton)
    {
        RemoveOldCardsFromSlider();

        _currentClickedButton = currentClickedButton;
        _currentCardsParent = _currentClickedButton.gameObject;
        _currentSliderCards = currentClickedButton.InstantiatedCards;

        _initCardsSize = _currentSliderCards[0].transform.localScale;

        foreach (var card in _currentSliderCards)
        {
            card.transform.parent = this.transform;
            card.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            card.transform.localScale = _initCardsSize * _cardsSizeOnSlider;
            card.SetActive(true);
        }
    }

    public void RemoveOldCardsFromSlider()
    {
        foreach (var card in _currentSliderCards)
        {
            card.SetActive(false);
            card.transform.parent = _currentCardsParent.transform;
            card.transform.localScale = _initCardsSize;
        }
    }
}
