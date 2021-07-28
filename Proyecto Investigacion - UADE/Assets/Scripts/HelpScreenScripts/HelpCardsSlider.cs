using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCardsSlider : MonoBehaviour
{
    public HelpGraphButton _currentClickedButton = null;
    public GameObject _currentCardsParent = null;
    public List<GameObject> _currentSliderCards = null;

    public void SetNewCardsOnSlider(HelpGraphButton currentClickedButton)
    {
        RemoveOldCardsFromSlider();

        _currentClickedButton = currentClickedButton;
        _currentCardsParent = _currentClickedButton.gameObject;
        _currentSliderCards = currentClickedButton.InstantiatedCards;

        foreach (var card in _currentSliderCards)
        {
            card.transform.parent = this.transform;
            card.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            card.SetActive(true);
        }
    }

    public void RemoveOldCardsFromSlider()
    {
        foreach (var card in _currentSliderCards)
        {
            card.SetActive(false);
            card.transform.parent = _currentCardsParent.transform;
        }
    }
}
