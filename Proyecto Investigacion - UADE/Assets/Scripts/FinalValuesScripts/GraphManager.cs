using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
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
            _progressBars[i].AssignValueLerp(Random.Range(0, 100));
        }
    }

    public void ResetGraphs()
    {
        for (int i = 0; i < _progressBars.Length; i++)
        {
            print("iteracion numero " + i + " el largo del array es de " + _progressBars.Length);
            _progressBars[i].ResetProgressBar();
        }
    }
}
