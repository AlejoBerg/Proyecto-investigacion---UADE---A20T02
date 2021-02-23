using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject _sceneToHide;
    [SerializeField] private GameObject _sceneToShow;
    [SerializeField] private GameObject _sceneToFadeOnce;
    [SerializeField] private float _fadeTime;

    public void OnChangeScenes()
    {
        FadeInOut();
    }

    public void OnChangeOneSceneAlpha(float endFade = 0)
    {
        CanvasGroup sceneToChangeCanvGroup = _sceneToFadeOnce.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(_sceneToFadeOnce, sceneToChangeCanvGroup.alpha, endFade));
    }

    private void FadeInOut() 
    {
        StartCoroutine(DoFade(_sceneToHide, 1, 0));

        _sceneToShow.SetActive(true);
        StartCoroutine(DoFade(_sceneToShow, 0, 1));
    }

    IEnumerator DoFade(GameObject sceneToChange, float startAlpha ,float endAlpha)
    {
        sceneToChange.SetActive(true);
        CanvasGroup sceneToChangeCanvGroup = sceneToChange.GetComponent<CanvasGroup>();
        float counter = 0;

        while (counter < _fadeTime)
        {
            counter += Time.deltaTime;
            sceneToChangeCanvGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / _fadeTime);

            yield return null;
        }

        if (sceneToChangeCanvGroup.alpha <= 0.01f)
        {
            sceneToChange.SetActive(false);
        }
    }
}
