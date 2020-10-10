using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler

{   public static GameObject itemDragging;
    private Vector3 startPos;
    private Transform startParentPos;
    private Transform dragParentPos;

    //[SerializeField] public GameObject itemDragging;

    private void Start()
    {
        dragParentPos = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       itemDragging = gameObject;
       startPos = transform.position;
       startParentPos = transform.parent;
       transform.SetParent(dragParentPos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
        itemDragging = null;
        if (transform.parent == dragParentPos)
        {
            transform.position = startPos;
            transform.SetParent(startParentPos);
        }
    }
}
