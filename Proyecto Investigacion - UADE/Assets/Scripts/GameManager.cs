using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager  : MonoBehaviour
{
    
    protected static List<Card> cards = new List<Card>();
    
    public static List<Card> Cards { get => cards; set => cards = value; }
}


