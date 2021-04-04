using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _helpButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _optionsGraphsButtons;

    [SerializeField] private Vector3 _maxSize;

    [SerializeField] private float _fadeInTime = 4f;
    [SerializeField] private float _fadeOutTime = 2f;

    private GameObject _currentObjectToShow;
    private ChangeScene _changeSceneRef;
    private float _elapsedRotTime = 0;
    private Quaternion _newRndRotation;

    private float _currentFadeOutTime = 0;
    private float _fadeOutCounter = 0;

    private GameObject _nextButtonToUnhide;

    private void Awake()
    {
        _changeSceneRef = GetComponent<ChangeScene>();
    }

    public void OnHelpButtonPressed(GameObject newGraphToShow) //Fade out scene , scale graph
    {
        float diff = Mathf.Abs(_fadeOutCounter - _currentFadeOutTime);
        if (diff <= 0.01f)
        {
            _helpButton.SetActive(false);
            _nextButtonToUnhide = _backButton;

            _changeSceneRef.OnChangeOneSceneAlpha(0);

            newGraphToShow.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            newGraphToShow.SetActive(true);
            StartCoroutine(LerpObjectSize(newGraphToShow, Vector3.zero, _maxSize, _fadeInTime, false));
            _optionsGraphsButtons.SetActive(true);
            _currentObjectToShow = newGraphToShow;
        }
    }

    public void OnBackFromHelpButtonPressed()//scale graph , Fade in scene  
    {
        float diff = Mathf.Abs(_fadeOutCounter - _currentFadeOutTime);
        if (diff <= 0.01f)
        {
            _backButton.SetActive(false);
            _nextButtonToUnhide = _helpButton;

            _changeSceneRef.OnChangeOneSceneAlpha(1);
            StartCoroutine(LerpObjectSize(_currentObjectToShow, _maxSize, Vector3.zero, _fadeOutTime, true));
            _optionsGraphsButtons.SetActive(false);
        }
    }

    public void OnChangeGraphPressed(GameObject newGraphToShow)
    {
        _currentObjectToShow.SetActive(false);

        newGraphToShow.SetActive(true);
        StartCoroutine(LerpObjectSize(newGraphToShow, Vector3.zero, _maxSize, _fadeInTime, false));
        _currentObjectToShow = newGraphToShow;
    }

    IEnumerator LerpObjectSize(GameObject newGraphToShow, Vector3 initialScaleSize, Vector3 endScaleSize, float scaleTime, bool shouldHideAfterScale)
    {
        _currentFadeOutTime = scaleTime;
        _fadeOutCounter = 0;
        newGraphToShow.transform.localScale = initialScaleSize;

        ManageButtonsActivationWithDelay(false);

        while (_fadeOutCounter < scaleTime)
        {
            _fadeOutCounter += Time.deltaTime;
            newGraphToShow.transform.localScale = Vector3.Lerp(newGraphToShow.transform.localScale, endScaleSize, _fadeOutCounter / scaleTime);
            yield return null;
        }

        ManageButtonsActivationWithDelay(true);
        if (shouldHideAfterScale) { newGraphToShow.SetActive(false); }
    }

    private void ManageButtonsActivationWithDelay(bool shouldActivate)
    {
        if (shouldActivate)
        {
            _nextButtonToUnhide.SetActive(true);
        }
        else
        {
            _nextButtonToUnhide.SetActive(false);
            _backButton.SetActive(false);
        }
    }
}
