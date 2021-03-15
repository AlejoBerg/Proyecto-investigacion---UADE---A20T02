using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _parentWhileDragging;
    [SerializeField] private Canvas _perspectiveCameraCanvas;

    private bool _played = false;
    private Transform _parentToReturnTo = null;
    private CanvasGroup _canvasGroup = null;
    private GameObject _placeHolder; //PlaceHolder position after moving the card
    private Transform _placeHolderParent; //PlaceHolder parent used for returning when changing dop zones

    public bool Played { get => _played; set => _played = value; }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        print($"el estado de Played la carta {this.gameObject.name} es {_played}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentToReturnTo = this.transform.parent;
        InitPlaceholder();

        this.transform.SetParent(_parentWhileDragging);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = _perspectiveCameraCanvas.planeDistance; //planeDistance = how far away from the camera is the canvas generated
        Camera renderCamera = _perspectiveCameraCanvas.worldCamera; // Sizing the camera based on world camera
        Vector3 canvasPos = renderCamera.ScreenToWorldPoint(screenPos); //Creates a screen space based on world space

        this.transform.position = canvasPos;
        _placeHolder.transform.SetParent(_placeHolderParent);
        //SwapCardsWhenNecessary();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(_parentToReturnTo);
        this.transform.SetSiblingIndex(_placeHolder.transform.GetSiblingIndex());
        _canvasGroup.blocksRaycasts = true;

        _placeHolder.SetActive(false);
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
