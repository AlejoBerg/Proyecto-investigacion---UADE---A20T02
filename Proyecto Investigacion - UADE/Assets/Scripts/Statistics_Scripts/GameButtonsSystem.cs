using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsSystem : MonoBehaviour
{
    [SerializeField] private GameObject _helpButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _finishMatchButton;
    [SerializeField] private GameObject _optionsGraphsButtons;

    [SerializeField] private Vector3 _maxSize;

    [SerializeField] private float _fadeInTime = 4f;
    [SerializeField] private float _fadeOutTime = 2f;

    private GameObject _currentObjectToShow;
    private ChangeScene _changeSceneRef;

    private float _currentFadeOutTime = 0;
    private float _fadeOutCounter = 0;

    public List<GameObject> _nextButtonsToUnhide;

    private void Awake()
    {
        _changeSceneRef = GetComponent<ChangeScene>();
    }

    public void OnHelpButtonPressed(GameObject newGraphToShow) //Fade out scene , scale graph
    {
        _helpButton.SetActive(false);

        _nextButtonsToUnhide.Clear();
        _nextButtonsToUnhide.Add(_backButton);
        _nextButtonsToUnhide.Add(_optionsGraphsButtons);

        _changeSceneRef.OnChangeOneSceneAlpha(0);

        newGraphToShow.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        newGraphToShow.SetActive(true);
        StartCoroutine(LerpObjectSize(newGraphToShow, Vector3.zero, _maxSize, _fadeInTime, false));

        _currentObjectToShow = newGraphToShow;
    }

    public void OnBackFromHelpButtonPressed()//scale graph , Fade in scene  
    {
        _backButton.SetActive(false);

        _nextButtonsToUnhide.Clear();
        _nextButtonsToUnhide.Add(_helpButton);
        _nextButtonsToUnhide.Add(_finishMatchButton);

        _changeSceneRef.OnChangeOneSceneAlpha(1);
        StartCoroutine(LerpObjectSize(_currentObjectToShow, _maxSize, Vector3.zero, _fadeOutTime, true));
        _optionsGraphsButtons.SetActive(false);
    }

    public void OnChangeGraphPressed(GameObject newGraphToShow)
    {
        _currentObjectToShow.SetActive(false);

        _nextButtonsToUnhide.Clear();
        _nextButtonsToUnhide.Add(_backButton);

        newGraphToShow.SetActive(true);
        StartCoroutine(LerpObjectSize(newGraphToShow, Vector3.zero, _maxSize, _fadeInTime, false));
        _currentObjectToShow = newGraphToShow;
    }

    IEnumerator LerpObjectSize(GameObject newGraphToShow, Vector3 initialScaleSize, Vector3 endScaleSize, float scaleTime, bool shouldHideAfterScale)
    {
        _currentFadeOutTime = scaleTime;
        _fadeOutCounter = 0;
        newGraphToShow.transform.localScale = initialScaleSize;

        ManageButtonsActivation(false);

        while (_fadeOutCounter < scaleTime)
        {
            _fadeOutCounter += Time.deltaTime;
            newGraphToShow.transform.localScale = Vector3.Lerp(newGraphToShow.transform.localScale, endScaleSize, _fadeOutCounter / scaleTime);
            yield return null;
        }

        ManageButtonsActivation(true);
        _nextButtonsToUnhide.Clear();
        if (shouldHideAfterScale) { newGraphToShow.SetActive(false); }
    }

    private void ManageButtonsActivation(bool shouldActivate)
    {
        if (shouldActivate)
        {
            foreach (var button in _nextButtonsToUnhide)
            {
                button.SetActive(true);
            }
        }
        else
        {
            foreach (var button in _nextButtonsToUnhide)
            {
                button.SetActive(false);
            }
        }
    }
}
