using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _minimum;
    [SerializeField] private float _maximum;
    [SerializeField] private float _lerpSpeed = 2f;
    [SerializeField] private Image _mask;
    [SerializeField] private TextMeshProUGUI _percentageText;

    private float _fillAmount = 0;
    private bool _shouldLerp = false;

    private void Update()
    {
        if (_shouldLerp == true)
        {
            _mask.fillAmount = Mathf.Lerp(_mask.fillAmount, _fillAmount, Time.deltaTime);
            var percentage = (int)(_mask.fillAmount * _maximum);
            _percentageText.text = " % " + percentage.ToString();
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
