using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectAnimation : MonoBehaviour
{
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

    private void Awake()
    {
        _changeSceneRef = GetComponent<ChangeScene>();
    }

    public void OnHelpButtonPressed()
    {
        float diff = Mathf.Abs(_fadeOutCounter - _currentFadeOutTime);
        if (diff <= 0.01f)
        {
            _changeSceneRef.OnChangeOneSceneAlpha(0);
            _shouldRotate = true;
            _objectToShowRef.transform.localScale = Vector3.zero;
            _objectToShowRef.SetActive(true);
            StartCoroutine(LerpObjectSize(Vector3.zero, _maxSize, _fadeInTime, false));
        }
    }

    public void OnBackFromHelpButtonPressed()
    {
        float diff = Mathf.Abs(_fadeOutCounter - _currentFadeOutTime);
        if (diff <= 0.01f)
        {
            _changeSceneRef.OnChangeOneSceneAlpha(1);
            _shouldRotate = false;
            StartCoroutine(LerpObjectSize(_maxSize, Vector3.zero, _fadeOutTime, true));
        }
        //Fade in de la game scene
    }

    private void Update()
    {
        if (_shouldRotate == true)
        {
            RandomObjectRotation(_rotateSpeed);
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

        if (shouldHideAfterScale) { _objectToShowRef.SetActive(false); }
    }

    private void RandomObjectRotation(float rotateTime)
    {
        if(_elapsedRotTime > rotateTime)
        {
            _elapsedRotTime = 0;
            _newRndRotation = Quaternion.Euler(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        }

        _objectToShowRef.transform.localRotation = Quaternion.Slerp(_objectToShowRef.transform.localRotation, _newRndRotation, Time.deltaTime * rotateTime);
        _elapsedRotTime += Time.deltaTime;
    }
}
