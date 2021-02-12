using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemPool : MonoBehaviour, IDropHandler
{
    [SerializeField] private DragUI itemDragging;
    [SerializeField] private Transform tablero;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (DragUI.itemDragging.CompareTag("Cards"))
        {
            //GameManager<DragUI>.Cards.Remove(itemDragging);
            Debug.Log("carta removida");
            DragUI.itemDragging.transform.SetParent(tablero);
        }
    }
}