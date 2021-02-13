using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private GameManager _gameManagerRef;
    [SerializeField] private float _coinsHudTimer = 0.2f;

    private float t = 0f;

    private void Awake()
    {
        _gameManagerRef.OnCoinsChange += OnCoinsChangeHandler;

        t = _gameManagerRef.CurrentCoins;
        _coinsText.text = Mathf.Round(t).ToString();
    }

    private void OnCoinsChangeHandler()
    {
        StartCoroutine(LerpTextCounterEffect());        
    }

    IEnumerator LerpTextCounterEffect()
    {
        while (t != _gameManagerRef.CurrentCoins)
        {
            t = Mathf.MoveTowards(t, _gameManagerRef.CurrentCoins, Time.deltaTime / _coinsHudTimer);
            _coinsText.text = Mathf.Round(t).ToString();

            yield return null;
        }
    }
}
