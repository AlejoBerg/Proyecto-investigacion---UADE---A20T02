using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _minimum;
    [SerializeField] private float _maximum;
    [SerializeField] private float _lerpSpeed = 0.1f;
    [SerializeField] private Image _mask;

    private float _current = 0;
    //private void Update()
    //{
    //    GetCurrentFill(10);
    //}

    public void GetCurrentFill(float progressBarValue)
    {
        _current = progressBarValue;
        float currentOffset = _current - _minimum;
        float maximumOffset = _maximum - _minimum;
        float fillAmount = (float)currentOffset / (float)maximumOffset;
        print($"currentOffset = {currentOffset} , maximumOffset = {maximumOffset} y fillAmount = {fillAmount}");

        _mask.fillAmount = fillAmount;
        //_mask.fillAmount = Mathf.Lerp(_minimum, fillAmount, Time.deltaTime * _lerpSpeed);
    }
}
