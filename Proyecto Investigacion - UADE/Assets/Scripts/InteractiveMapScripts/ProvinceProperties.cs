using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProvinceProperties")]
public class ProvinceProperties : ScriptableObject
{
    [SerializeField] private int _initialGameCoins = 5;
    [SerializeField] private int _amountOfPlays = 5;
    [SerializeField] private string _gameplayCaseID = "";
    [SerializeField] private string[] _cardsIDs;

    public int InitialGameCoins { get => _initialGameCoins; }
    public int AmountOfPlays { get => _amountOfPlays; }
    public string GameplayCaseID { get => _gameplayCaseID; }
    public string[] CardsIDs { get => _cardsIDs; }
}
