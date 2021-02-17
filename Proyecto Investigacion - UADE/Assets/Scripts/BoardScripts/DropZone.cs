using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private enum DropZoneType { DECK_OF_CARDS, BOARD };
    private Draggable _draggeable = null;
    private float _newBoardRotation = 0;

    [SerializeField] private GameManager _gameManagerRef;
    [SerializeField] private DropZoneType _dropZoneType = DropZoneType.BOARD;

    public void OnDrop(PointerEventData eventData)
    {
        if (_draggeable != null) 
        {
            _draggeable.ChangeParent(this.transform);
            _draggeable.transform.eulerAngles = new Vector3(_newBoardRotation, _draggeable.transform.eulerAngles.y, _draggeable.transform.eulerAngles.z);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        _draggeable = eventData.pointerDrag.GetComponent<Draggable>();

        if (_draggeable != null)
        {
            _draggeable.ChangePlaceHolderParent(this.transform.parent); // I am changing just the placeholder parent because if I change parent too, if y didnt wanted to leave the card on the other drop zone it will leave it anyway
            CheckCoinChanges(_draggeable);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        if (_draggeable != null)
        {
            _draggeable.Played = false;
            _draggeable.ChangePlaceHolderParent(this.transform);
        }
    }

    private void CheckCoinChanges(Draggable draggeable)
    {
        if(draggeable.Played == false && _dropZoneType == DropZoneType.BOARD)
        {
            draggeable.Played = true;
            float cardCost = draggeable.GetComponent<CardDisplay>().CardCost;
            _newBoardRotation = 45;
            _gameManagerRef.ChangeCoins(-cardCost);
        }
        else if (draggeable.Played == true && _dropZoneType == DropZoneType.DECK_OF_CARDS)
        {
            draggeable.Played = false;
            float cardCost = draggeable.GetComponent<CardDisplay>().CardCost;
            _newBoardRotation = 0;
            _gameManagerRef.ChangeCoins(cardCost);
        }
    }
}
