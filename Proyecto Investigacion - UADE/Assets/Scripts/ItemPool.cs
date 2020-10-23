using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemPool : MonoBehaviour, IDropHandler
{
    //[SerializeField] private DragUI itemDragging;
    [SerializeField] private Transform tableroAzul;
    [SerializeField] private Transform tableroAmarrillo;
    [SerializeField] private Transform tableroVerde;
    
    public void OnDrop(PointerEventData eventData)
    {

        if (DragUI.itemDragging.CompareTag("Blue"))
        {
            DragUI.itemDragging.transform.SetParent(tableroAzul);
        }
        
        
        if (DragUI.itemDragging.CompareTag("Green"))
        {
            DragUI.itemDragging.transform.SetParent(tableroVerde);
        }
        
        
        if (DragUI.itemDragging.CompareTag("Yellow"))
        {
            DragUI.itemDragging.transform.SetParent(tableroAmarrillo);
        }
    }
}
