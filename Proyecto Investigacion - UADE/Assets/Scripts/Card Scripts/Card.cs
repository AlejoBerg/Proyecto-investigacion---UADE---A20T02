using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card: ScriptableObject
{
    private enum ElementSlots { WATER, CLIMATECHANGE, DRAINAGE };

    [SerializeField] private int cardID;
    [SerializeField] private string balance = "";
    [SerializeField] private ElementSlots element = ElementSlots.WATER;

    [SerializeField] private string cardName = "";
    [SerializeField] private string cardDescription = "";
    [SerializeField] private Sprite cardBackground = null; //Blue - Green - Yellow
    [SerializeField] private int moneyCost = 0;
    [SerializeField] private int timeCost = 0;
    [SerializeField] private int peopleHappiness = 0;

    public int CardID { get => cardID; }
    public string Balance { get => balance; }
    private ElementSlots Element { get => element; }

    public int PeopleHappiness { get => peopleHappiness;}
    public int TimeCost { get => timeCost;}
    public int MoneyCost { get => moneyCost;}
    public Sprite CardBackground { get => cardBackground;}
    public string CardDescription { get => cardDescription;}
    public string CardName { get => cardName;}
}
