using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private ProgressBar[] _progressBars;

    public void OnFinishButton()
    {
        GetGraphValues();
    }

    private void GetGraphValues()
    {
        for (int i = 0; i < _progressBars.Length; i++)
        {
            _progressBars[i].GetCurrentFill(10);
        }
    }
}
