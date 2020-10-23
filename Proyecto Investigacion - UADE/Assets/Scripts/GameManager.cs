using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager  <T>: MonoBehaviour
{
    
    protected static List<T> cards = new List<T>();
    
    public static List<T> Cards { get => cards; set => cards = value; }
}


