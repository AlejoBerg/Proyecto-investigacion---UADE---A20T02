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

    private float _elapsedRotTime = 0;
    private Quaternion _newRndRotation;
    private bool _shouldRotate = false;

    public void OnHelpButtonPressed()
    {
        //Fade out de la game scene
        _objectToShowRef.transform.localScale = Vector3.zero;
        _objectToShowRef.SetActive(true);
        StartCoroutine(LerpObjectSize(_maxSize, _fadeInTime));
    }

    public void OnBackFromHelpButtonPressed()
    {
        StartCoroutine(LerpObjectSize(Vector3.zero, _fadeOutTime)); // >> Por algun motivo el "counter / scaleTime" aca siempre se mantiene en el mismo numero, chequear eso

        //Escalar el prefab mediante un lerp a 0
        //Luego de escalar, ocultarlo
        //Fade in de la game scene
    }

    private void Update()
    {
        if (_shouldRotate == true)
        {
            RandomObjectRotation(_rotateSpeed);
        }

        TemporaryInputCheck();//Just for testing purpose
    }

    IEnumerator LerpObjectSize(Vector3 endScaleSize, float scaleTime)
    {
        float counter = 0;

        while (counter < scaleTime)
        {
            counter += Time.deltaTime;
            _objectToShowRef.transform.localScale = Vector3.Lerp(_objectToShowRef.transform.localScale, endScaleSize, counter / scaleTime);
            yield return null;
        }
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

    private void TemporaryInputCheck() 
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            _shouldRotate = true;
            _objectToShowRef.transform.localScale = Vector3.zero;
            _objectToShowRef.SetActive(true);
            StartCoroutine(LerpObjectSize(_maxSize, _fadeInTime));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            _shouldRotate = false;
            StartCoroutine(LerpObjectSize(Vector3.zero, _fadeOutTime));
        }
    }
}
