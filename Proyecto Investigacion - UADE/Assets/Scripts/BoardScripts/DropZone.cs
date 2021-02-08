using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Draggable _draggeable = null;

    public void OnDrop(PointerEventData eventData)
    {
        //Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (_draggeable != null)
        {
            _draggeable.ChangeParent(this.transform);
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

        //Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (_draggeable != null)
        {
            _draggeable.ChangePlaceHolderParent(this.transform);
        }
    }
}
