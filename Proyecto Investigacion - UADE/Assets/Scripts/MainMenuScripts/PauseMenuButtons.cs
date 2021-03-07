using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeSceneRef;
    private bool _isPaused = false;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            _isPaused = true;
            _changeSceneRef.OnChangeOneSceneAlpha(1);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
        {
            _isPaused = false;
            _changeSceneRef.OnChangeOneSceneAlpha(0);
        }
    }
}
