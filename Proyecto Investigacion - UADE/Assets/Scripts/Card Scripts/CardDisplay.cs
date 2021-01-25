using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    //Le paso las referencias solamente de los textos para que en start visualmente se seteen
    [SerializeField] private Card card;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;
    [SerializeField] private Image cardBackgroundImage;
    [SerializeField] private TextMeshProUGUI moneyCostText;
    [SerializeField] private TextMeshProUGUI timeCostText;
    [SerializeField] private TextMeshProUGUI peopleHappinessText;

    public TextMeshProUGUI CardDescriptionText { get => cardDescriptionText;}

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
