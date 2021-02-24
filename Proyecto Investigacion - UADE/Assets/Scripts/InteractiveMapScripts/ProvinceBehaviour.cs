using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProvinceBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private InteractiveMapCameraController _cameraControllerRef;
    [SerializeField] private Vector3 _backButtonOffset;
    [SerializeField] private Vector3 _playButtonOffset;
    [SerializeField] private GameObject _backButtonRef;
    [SerializeField] private GameObject _playGameButtonRef;
    [SerializeField] private float _delayBeforeShowingButtons = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        print($"clickeo sobre {this.name}");
        _cameraControllerRef.AssignNewFieldViewAndTarget(10, this.transform, this.transform);
        StartCoroutine(AdjustButtons());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Glow
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Sacar Glow
    }

    IEnumerator AdjustButtons()
    {
        yield return new WaitForSeconds(_delayBeforeShowingButtons);
        ButtonsAdjustments();
    }

    private void ButtonsAdjustments()
    {
        _backButtonRef.transform.position = this.transform.position - _backButtonOffset;
        _backButtonRef.SetActive(true);

        _playGameButtonRef.transform.position = this.transform.position + _playButtonOffset;
        _playGameButtonRef.SetActive(true);
    }
}
