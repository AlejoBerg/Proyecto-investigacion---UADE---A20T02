﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
   // [SerializeField] private DragUI itemDragging;

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            item = DragUI.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }
}
