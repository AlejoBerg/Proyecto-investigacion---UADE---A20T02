using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private enum DropZoneType { DECK_OF_CARDS, BOARD };
    private Draggable _draggeable = null;

    [SerializeField] private GameManager _gameManagerRef;
    [SerializeField] private DropZoneType _dropZoneType = DropZoneType.BOARD;

    public void OnDrop(PointerEventData eventData)
    {
        float cardCost = _draggeable.GetComponent<CardDisplay>().CardCost;

        if (_draggeable != null) 
        {
            CheckCoinChanges(_draggeable, cardCost);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        _draggeable = eventData.pointerDrag.GetComponent<Draggable>();

        if (_draggeable != null)
        {
            _draggeable.ChangePlaceHolderParent(this.transform.parent); // I am changing just the placeholder parent because if I change parent too, if y didnt wanted to leave the card on the other drop zone it will leave it anyway
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        if (_draggeable != null)
        {
            _draggeable.ChangePlaceHolderParent(this.transform);
        }
    }

    private void CheckCoinChanges(Draggable draggeable, float cardCost) //Coins manager condition
    {
        if(draggeable.Played == false && _dropZoneType == DropZoneType.BOARD)
        {
            if(_gameManagerRef.CurrentCoins >= cardCost)
            {
                draggeable.Played = true;
                _gameManagerRef.ChangeCoins(-cardCost);
                draggeable.ChangeParent(this.transform);
            }
        }
        else if (draggeable.Played == true && _dropZoneType == DropZoneType.DECK_OF_CARDS)
        {
            draggeable.Played = false;
            _gameManagerRef.ChangeCoins(cardCost);
            draggeable.ChangeParent(this.transform);
        }
    }
}
