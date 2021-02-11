using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _minimum;
    [SerializeField] private float _maximum;
    [SerializeField] private float _lerpSpeed = 2f;
    [SerializeField] private Image _mask;

    private float _fillAmount = 0;
    private bool _shouldLerp = false;

    private void Update()
    {
        if(_shouldLerp == true)
        {
            _mask.fillAmount = Mathf.Lerp(_mask.fillAmount, _fillAmount, Time.deltaTime);
        }
    }

    public void AssignValueLerp(float finalValue)
    {
        float currentOffset = finalValue - _minimum;
        float maximumOffset = _maximum - _minimum;
        _fillAmount = (float)currentOffset / (float)maximumOffset;
        _shouldLerp = true;
    }

    public void ResetProgressBar()
    {
        _mask.fillAmount = 0;
        _fillAmount = 0;
    }
}
