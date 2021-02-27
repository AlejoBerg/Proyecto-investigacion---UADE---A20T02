using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProvinceBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private InteractiveMapCameraController _cameraControllerRef;

    //Buttons Variables
    [SerializeField] private Vector3 _backButtonOffset;
    [SerializeField] private Vector3 _playButtonOffset;
    [SerializeField] private GameObject _backButtonRef;
    [SerializeField] private GameObject _playGameButtonRef;
    [SerializeField] private float _delayBeforeShowingButtons = 1;

    //Image Effects Variables
    [SerializeField] private GameObject _blurImage;

    //Province descriptions
    [SerializeField] private GameObject _provinceDescription;

    private Image _currentImage;
    private Color _currentImageColor;
    private InteractiveMapButtons _interactiveMapButtonRef;
    private bool _isFocused = false;

    private void Awake()
    {
        _interactiveMapButtonRef = _backButtonRef.GetComponent<InteractiveMapButtons>();
        _interactiveMapButtonRef.OnBackButtonPressed += OnBackButtonPressedHandler;

        _currentImage = this.GetComponentInChildren<Image>();

        _currentImageColor = _currentImage.color;
        _currentImageColor.a = 0;
        _currentImage.color = _currentImageColor; // Ahora, cuando vuelvas lo que vas a tener que hacer es que el cambio de alfa lo haga cada vez que te paras encima y cuando salis

        _provinceDescription.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _cameraControllerRef.AssignNewFieldViewAndTarget(10, this.transform, this.transform);
        StartCoroutine(AdjustButtons());

        _currentImage.enabled = true;

        _blurImage.transform.SetAsLastSibling();
        _blurImage.SetActive(true);
        this.transform.SetAsLastSibling();

        _provinceDescription.SetActive(true);

        _isFocused = true;
        _currentImageColor.a = 100;
        _currentImage.color = _currentImageColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isFocused) 
        {
            _currentImageColor.a = 100;
            _currentImage.color = _currentImageColor;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isFocused)
        {
            _currentImageColor.a = 0;
            _currentImage.color = _currentImageColor;
        }
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

    private void OnBackButtonPressedHandler()
    {
        _provinceDescription.SetActive(false);

        _currentImageColor.a = 0;
        _currentImage.color = _currentImageColor;

        _blurImage.SetActive(false);
        _isFocused = false;
    }
}
