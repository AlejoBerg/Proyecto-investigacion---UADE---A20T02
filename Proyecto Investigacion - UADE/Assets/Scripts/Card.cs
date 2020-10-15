using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card: ScriptableObject
{
    [SerializeField] private string cardName = "";
    [SerializeField] private string cardDescription = "";
    [SerializeField] private Sprite cardBackground = null; //Blue - Green - Yellow
    [SerializeField] private Sprite cardArtwork = null; 
    [SerializeField] private int moneyCost = 0;
    [SerializeField] private int timeCost = 0;
    [SerializeField] private int peopleHappiness = 0;

    public int PeopleHappiness { get => peopleHappiness;}
    public int TimeCost { get => timeCost;}
    public int MoneyCost { get => moneyCost;}
    public Sprite CardBackground { get => cardBackground;}
    public Sprite CardArtwork { get => cardArtwork;}
    public string CardDescription { get => cardDescription;}
    public string CardName { get => cardName;}
}
