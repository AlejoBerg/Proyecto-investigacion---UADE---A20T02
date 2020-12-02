using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    //Le paso las referencias solamente de los textos para que en start visualmente se seteen
    [SerializeField] private Card card;
    [SerializeField] private Text cardNameText;
    [SerializeField] private Text cardDescriptionText;
    [SerializeField] private Image cardBackgroundImage;
    [SerializeField] private Text moneyCostText;
    [SerializeField] private Text timeCostText;
    [SerializeField] private Text peopleHappinessText;

    private void Start()
    {
        cardNameText.text = card.CardName;
        cardDescriptionText.text = card.CardDescription;
        cardBackgroundImage.sprite = card.CardBackground;
        moneyCostText.text = card.MoneyCost.ToString(); 
        timeCostText.text = card.TimeCost.ToString(); 
        peopleHappinessText.text = card.PeopleHappiness.ToString(); 
    }
}
