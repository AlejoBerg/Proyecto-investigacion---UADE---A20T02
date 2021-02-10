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
    [SerializeField] private ShowExtraInfo _showExtraInfoCard;

    private GameObject _zoomedCard;
    private string _zoomedCardDescription;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_zoomedCard == null)
        {
            InitializeZoomedCard();
        }

        _showExtraInfoCard.ChangeShowingObject(_zoomedCard);
        _showExtraInfoCard.ChangeObjectDescription(_zoomedCardDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    private void InitializeZoomedCard()
    {
        _zoomedCard = Instantiate(this.gameObject, transform.position, Quaternion.identity);
        _zoomedCard.transform.localScale = new Vector3(transform.localScale.x * _zoomScaleAmount, transform.localScale.y * _zoomScaleAmount, transform.localScale.z * _zoomScaleAmount);

        _zoomedCardDescription = _zoomedCard.GetComponent<CardDisplay>().CardDescriptionText.text;
        Destroy(_zoomedCard.GetComponent<MouseHoverCard>());

        _zoomedCard.SetActive(false);
    }
}
