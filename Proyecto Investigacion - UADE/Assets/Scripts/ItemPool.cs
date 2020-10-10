using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemPool : MonoBehaviour, IDropHandler
{
    //[SerializeField] private DragUI itemDragging;
    
    public void OnDrop(PointerEventData eventData)
    {
        DragUI.itemDragging.transform.SetParent(transform);
    }
}
