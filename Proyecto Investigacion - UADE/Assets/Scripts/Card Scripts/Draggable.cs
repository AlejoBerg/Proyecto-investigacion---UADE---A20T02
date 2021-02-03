using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform _parentToReturnTo = null;
    private CanvasGroup _canvasGroup = null;
    private GameObject _placeHolder; //PlaceHolder position after moving the card
    private Transform _placeHolderParent; //PlaceHolder parent used for returning when changing dop zones

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentToReturnTo = this.transform.parent;

        InitPlaceholder();

        this.transform.SetParent(this.transform.parent.parent);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        _placeHolder.transform.SetParent(_placeHolderParent);

        SwapCardsWhenNecessary();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(_parentToReturnTo);
        this.transform.SetSiblingIndex(_placeHolder.transform.GetSiblingIndex());
        _canvasGroup.blocksRaycasts = true;

        _placeHolder.SetActive(false); //Hacer que cachee en el awake este placeholder y que lo desactive. Todo lo relacionado con este placeholder metelo en una funcion tipo "InitCardPlaceholder" y despues a la carta le pisas los valores
    }

    private void SwapCardsWhenNecessary()
    {
        int newSiblingIndex = _placeHolderParent.childCount;

        for (int i = 0; i < _placeHolderParent.childCount; i++)
        {
            if (this.transform.position.x < _placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (_placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        _placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    private void InitPlaceholder()
    {
        if(_placeHolder == null)
        {
            _placeHolder = new GameObject();
            _placeHolder.transform.SetParent(this.transform.parent);

            LayoutElement dummyLayoutElem = _placeHolder.AddComponent<LayoutElement>();
            LayoutElement currLayoutElem = this.GetComponent<LayoutElement>();

            dummyLayoutElem.preferredWidth = currLayoutElem.preferredWidth;
            dummyLayoutElem.preferredHeight = currLayoutElem.preferredHeight;
            dummyLayoutElem.flexibleHeight = 0;
            dummyLayoutElem.flexibleWidth = 0;
        }
        else 
        { 
            _placeHolder.SetActive(true); 
        }

        _placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        _placeHolderParent = _parentToReturnTo;
    }

    public void ChangeParent(Transform newParent)
    {
        _parentToReturnTo = newParent;
    }

    public void ChangePlaceHolderParent(Transform newPlaceholderParent)
    {
        _placeHolderParent = newPlaceholderParent;
    }
}
