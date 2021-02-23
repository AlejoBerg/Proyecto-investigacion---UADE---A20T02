using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _helpButton;
    [SerializeField] private GameObject _backButton;

    [SerializeField] private GameObject _objectToShowRef;
    [SerializeField] private Vector3 _maxSize;

    [SerializeField] private float _fadeInTime = 4f;
    [SerializeField] private float _fadeOutTime = 2f;
    [SerializeField] private float _rotateSpeed = 2f;

    private ChangeScene _changeSceneRef;
    private float _elapsedRotTime = 0;
    private Quaternion _newRndRotation;
    private bool _shouldRotate = false;

    private float _currentFadeOutTime = 0;
    private float _fadeOutCounter = 0;

    private GameObject _nextButtonToUnhide;

    private void Awake()
    {
        _changeSceneRef = GetComponent<ChangeScene>();
    }

    private void Update()
    {
        if (_shouldRotate == true)
        {
            RandomObjectRotation(_rotateSpeed);
        }
    }

    public void OnHelpButtonPressed() //Fade out scene , scale graph
    {
        float diff = Mathf.Abs(_fadeOutCounter - _currentFadeOutTime);
        if (diff <= 0.01f)
        {
            _helpButton.SetActive(false);
            _nextButtonToUnhide = _backButton;

            _changeSceneRef.OnChangeOneSceneAlpha(0);
            _shouldRotate = true;
            //_objectToShowRef.transform.localScale = Vector3.zero;
            _objectToShowRef.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            _objectToShowRef.SetActive(true);
            StartCoroutine(LerpObjectSize(Vector3.zero, _maxSize, _fadeInTime, false));
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
            _shouldRotate = false;
            StartCoroutine(LerpObjectSize(_maxSize, Vector3.zero, _fadeOutTime, true));
        }
    }

    IEnumerator LerpObjectSize(Vector3 initialScaleSize, Vector3 endScaleSize, float scaleTime, bool shouldHideAfterScale)
    {
        _currentFadeOutTime = scaleTime;
        _fadeOutCounter = 0;
        _objectToShowRef.transform.localScale = initialScaleSize;

        while (_fadeOutCounter < scaleTime)
        {
            _fadeOutCounter += Time.deltaTime;
            _objectToShowRef.transform.localScale = Vector3.Lerp(_objectToShowRef.transform.localScale, endScaleSize, _fadeOutCounter / scaleTime);
            yield return null;
        }

        _nextButtonToUnhide.SetActive(true);
        if (shouldHideAfterScale) { _objectToShowRef.SetActive(false); }
    }

    private void RandomObjectRotation(float rotateTime)
    {
        if(_elapsedRotTime > rotateTime)
        {
            _elapsedRotTime = 0;
            _newRndRotation = Quaternion.Euler(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        }

        _objectToShowRef.transform.localRotation = Quaternion.Slerp(_objectToShowRef.transform.localRotation, _newRndRotation, Time.deltaTime * rotateTime);
        _elapsedRotTime += Time.deltaTime;
    }
}
