using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject _sceneToHide;
    [SerializeField] private GameObject _sceneToShow;
    [SerializeField] private float _fadeTime;

    public void OnChangeScene()
    {
        Fade();
        // 1- Hacer fade 
        // 2 - Sumar las monedas
        // 3 - Resetear los valores de la partida para cuando volves a jugar
    }

    private void Fade()
    {
        StartCoroutine(DoFade(_sceneToHide, true, 1, 0));

        _sceneToShow.SetActive(true);
        StartCoroutine(DoFade(_sceneToShow, false, 0, 1));
    }

    IEnumerator DoFade(GameObject sceneToChange, bool hideAfterFade, float startAlpha ,float endAlpha)
    {
        CanvasGroup sceneToChangeCanvGroup = sceneToChange.GetComponent<CanvasGroup>();
        float counter = 0;

        while (counter < _fadeTime)
        {
            counter += Time.deltaTime;
            sceneToChangeCanvGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / _fadeTime);

            yield return null;
        }

        if (hideAfterFade)
        {
            sceneToChange.SetActive(false);
        }
    }
}
