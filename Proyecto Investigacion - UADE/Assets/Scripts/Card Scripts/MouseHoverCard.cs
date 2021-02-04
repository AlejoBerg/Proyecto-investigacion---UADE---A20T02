using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MouseHoverCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _zoomScaleAmount = 2;
    [SerializeField] private Canvas _mainCanvasRef;
    [SerializeField] private Transform _zoomCardPosition;
    [SerializeField] private TextMeshProUGUI _zoomCardDescriptionText;

    private GameObject _zoomedCard;
    private string _zoomedCardDescription;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_zoomedCard == null)
        {
            InitializeZoomedCard();
        }

        SetDescriptionText(_zoomedCardDescription);
        _zoomedCard.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetDescriptionText("");
        _zoomedCard.SetActive(false);
    }

    private void InitializeZoomedCard()
    {
        print("la posicion del _zoomCardPosition.localPosition = " + _zoomCardPosition.localPosition);
        _zoomedCard = Instantiate(this.gameObject, _zoomCardPosition.localPosition, Quaternion.identity);
        print("la posicion de la nueva carta es = " + _zoomedCard.transform.localPosition);
        _zoomedCard.transform.localScale = new Vector3(transform.localScale.x * _zoomScaleAmount, transform.localScale.y * _zoomScaleAmount, transform.localScale.z * _zoomScaleAmount);
        _zoomedCard.transform.SetParent(_zoomCardPosition.parent, false);

        _zoomedCardDescription = _zoomedCard.GetComponent<CardDisplay>().CardDescriptionText.text;
        Destroy(_zoomedCard.GetComponent<MouseHoverCard>());
    }

    private void SetDescriptionText(string newText)
    {
        _zoomCardDescriptionText.text = newText;
    }
}
